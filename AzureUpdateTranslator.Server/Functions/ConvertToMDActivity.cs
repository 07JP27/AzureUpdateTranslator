using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AzureUpdateTranslator.Share.Dtos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureUpdateTranslator.Server
{
    public class ConvertToMDActivity
    {
        private readonly HttpClient _client;
        public ConvertToMDActivity(HttpClient client)
        {
            this._client = client;
        }

        [FunctionName("ConvertToMDActivity")]
        public async Task<string> SayHello([ActivityTrigger] RequestItem item, ILogger log)
        {
            var doc = default(IHtmlDocument);
            using (var stream = await this._client.GetStreamAsync(new Uri(item.Url)))
            {
                // AngleSharp.Html.Parser.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(stream);
            }

            var title = doc.QuerySelector("#main > div > div:nth-child(2) > div.column.medium-8 > div.row.row-size2.column > h1");
            var tags = doc.QuerySelector("ul.tags");
            var body = doc.QuerySelector("#main > div > div:nth-child(2) > div.column.medium-8 > div.row.row-size2.row-divided > div > div:nth-child(1)");

            log.LogInformation($"Saying hello to {item.Url}.");
            return $"Hello {item.Url}!";
        }
    }
}