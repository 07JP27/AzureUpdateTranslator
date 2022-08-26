using System;
using System.Net.Http;
using System.Threading.Tasks;
using AzureUpdateTranslator.Server.Models;
using DeepL;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace AzureUpdateTranslator.Server
{
    public class ConvertToMDActivity
    {
        private readonly HttpClient _client;
        private readonly Translator _deepl;
        public ConvertToMDActivity(HttpClient client, Translator deepl)
        {
            this._client = client;
            this._deepl = deepl;
        }

        [FunctionName("ConvertToMDActivity")]
        public async Task<string> ConvertToMD([ActivityTrigger] ConvertToMDParam param, ILogger log)
        {
            try
            {
                log.LogInformation($"Converting:{param.Url}");
                AzUpdateTopic topic = new AzUpdateTopic(param.Url, param.NoTranslate, param.Translator, this._client, this._deepl);
                return await topic.GenerateMDAsync();
            }
            catch (Exception e)
            {
                return $"## マークダウンファイル生成中にエラーが発生したためこのトピックのマークダウンは生成されませんでした。\r\n\r\n 対象URL:{param.Url} \r\n\r\n エラーメッセージ: \r\n\r\n {e.Message} \r\n\r\n";
            }
        }
    }
}
