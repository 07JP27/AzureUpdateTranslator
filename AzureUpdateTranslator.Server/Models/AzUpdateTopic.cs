using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AzureUpdateTranslator.Server.Dtos;
using AzureUpdateTranslator.Share.Constants;
using DeepL;
using Newtonsoft.Json;

namespace AzureUpdateTranslator.Server.Models
{
    public class AzUpdateTopic
    {
        private readonly HttpClient _client;
        private readonly Translator _deepl;
        private readonly string ExclusionTags = Environment.GetEnvironmentVariable("ExclusionTags");

        private string Title;
        private string TopicTitle;
        private List<string> Tags;
        private string TopicUrl;
        private IHtmlCollection<IElement> Body;
        private bool noTranslate;
        private string translator;

        public AzUpdateTopic(string url, bool noTranslate, string translator, HttpClient client, Translator deepl)
        {
            this._client = client;
            this._deepl = deepl;
            this.TopicUrl = url;
            this.noTranslate = noTranslate;
            this.translator = translator;
        }

        public async Task<string> GenerateMDAsync()
        {
            var stream = await this._client.GetStreamAsync(new Uri(this.TopicUrl));
            var parser = new HtmlParser();
            var doc = await parser.ParseDocumentAsync(stream);
            ParseHtml(doc);
            var result =  GenerateResultMDAsync();
            return await result;
        }

        private void ParseHtml(IHtmlDocument doc)
        {
            // title
            var titleElm = doc.QuerySelector("#main > div > div:nth-child(2) > div.column.medium-8 > div.row.row-size2.column > h1");
            this.TopicTitle = titleElm.TextContent;
            this.Title = titleElm.TextContent;

            // tag(target) exclusion by exclusion tag list
            var tagElms = doc.QuerySelectorAll("ul.tags > li");
            var tags = tagElms.Select(x => x.TextContent).ToList();
            tags.RemoveAll(x => ExclusionTags.Split(",").Contains(x));
            this.Tags = tags;

            // body
            var bodyElm = doc.QuerySelector("#main > div > div:nth-child(2) > div.column.medium-8 > div.row.row-size2.row-divided > div > div:nth-child(1)");
            this.Body = bodyElm.Children;
        }

        private async Task<string> GenerateResultMDAsync()
        {
            var converter = new ReverseMarkdown.Converter();
            var builder = new StringBuilder();

            builder.Append($"## {await TranslateAsync(this.Title)}\r\n");
            builder.Append("* 対象\r\n");
            this.Tags.ForEach(x => builder.Append($"  * {x}\r\n"));
            builder.Append("\r\n<br/>\r\n\r\n");
            builder.Append("* 内容\r\n");

            foreach (var elm in this.Body)
            {
                switch (elm.TagName)
                {
                    case "P":
                    case "H2":
                    case "DIV":
                        builder.Append($"  * {await TranslateAsync(converter.Convert(elm.InnerHtml))}\r\n");
                        break;
                    case "UL":
                        foreach(var child in elm.Children)
                        {
                            builder.Append($"    * {await TranslateAsync(converter.Convert(child.InnerHtml))}\r\n");
                        };
                        break;
                    case "OL":
                        foreach (var child in elm.Children)
                        {
                            builder.Append($"    1. {await TranslateAsync(converter.Convert(child.InnerHtml))}\r\n");
                        };
                        break;
                    default:
                        break;
                }
            }

            builder.Append("\r\n<br/>\r\n\r\n");
            builder.Append("* 参考\r\n");
            builder.Append($"  * {this.TopicTitle}\r\n");
            builder.Append($"    * [{this.TopicUrl}]({this.TopicUrl})\r\n");

            
            return builder.ToString();
        }

        private async Task<string> TranslateAsync(string original)
        {
            if(this.noTranslate == true)
            {
                return original;
            }

            if (translator == TranslatorOption.Cognitive)
            {
                object[] body = new object[] { new { Text = original } };
                var requestBody = JsonConvert.SerializeObject(body);

                var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from=en&to=ja");
                request.Headers.Add("Ocp-Apim-Subscription-Key", Environment.GetEnvironmentVariable("CognitiveAuthKey"));
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                var transResponse = await this._client.SendAsync(request);
                var transResult = JsonConvert.DeserializeObject<List<TranslationsDto>>(await transResponse.Content.ReadAsStringAsync());
                return transResult[0].Translations[0].Text;
            }
            else
            {
                var transResult = await this._deepl.TranslateTextAsync(original, LanguageCode.English, LanguageCode.Japanese);
                return transResult.Text;
            }   
        }
    }
}
