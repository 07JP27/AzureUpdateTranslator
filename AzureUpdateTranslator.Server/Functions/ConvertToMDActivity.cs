using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AzureUpdateTranslator.Server.Models;
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
        public async Task<string> ConvertToMD([ActivityTrigger] ConvertToMDParam param, ILogger log)
        {
            log.LogInformation($"Converting:{param.Url}");
            AzUpdateTopic topic = new AzUpdateTopic(param.Url, param.NoTranslate, this._client);
            return await topic.GenerateMDAsync();
        }
    }
}