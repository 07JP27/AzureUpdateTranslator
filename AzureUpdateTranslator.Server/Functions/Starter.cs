using System.Net.Http;
using System.Threading.Tasks;
using AzureUpdateTranslator.Share.Dtos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureUpdateTranslator.Server.Functions
{
    public static class Starter
    {
        [FunctionName("starter")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string requestJsonStr = await req.Content.ReadAsStringAsync();
            RequestDto data = JsonConvert.DeserializeObject<RequestDto>(requestJsonStr);

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync<RequestDto>("Orchestrator", data);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}