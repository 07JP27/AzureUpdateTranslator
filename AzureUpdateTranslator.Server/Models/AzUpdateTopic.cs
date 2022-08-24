using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Google.Protobuf.WellKnownTypes;
using ReverseMarkdown.Converters;

namespace AzureUpdateTranslator.Server.Models
{
    public class AzUpdateTopic
    {
        private readonly HttpClient _client;
        private readonly string ExclusionTags = Environment.GetEnvironmentVariable("ExclusionTags");

        private string Title;
        private string TopicTitle;
        private List<string> Tags;
        private string TopicUrl;
        private IHtmlCollection<IElement> Body;
        private bool doTranslate;

        public AzUpdateTopic(string url, bool doTranslate, HttpClient client)
        {
            this._client = client;
            this.TopicUrl = url;
            this.doTranslate = doTranslate;
        }

        public async Task<string> GenerateMDAsync()
        {
            var stream = await this._client.GetStreamAsync(new Uri(this.TopicUrl));
            var parser = new HtmlParser();
            var doc = await parser.ParseDocumentAsync(stream);
            ParseHtml(doc);
            var result =  GenerateResultMD();
            return result;
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

        private string GenerateResultMD()
        {
            var converter = new ReverseMarkdown.Converter();
            var builder = new StringBuilder();

            builder.Append($"## {this.Title}\r\n");
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
                        builder.Append($"  * {converter.Convert(elm.InnerHtml)}\r\n");
                        break;
                    case "UL":
                        foreach(var child in elm.Children)
                        {
                            builder.Append($"    * {converter.Convert(child.InnerHtml)}\r\n");
                        };
                        break;
                    case "OL":
                        foreach (var child in elm.Children)
                        {
                            builder.Append($"    1. {converter.Convert(child.InnerHtml)}\r\n");
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
    }
}
