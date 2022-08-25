using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using AzureUpdateTranslator.Share.Dtos;
using AzureUpdateTranslator.Server.Models;

namespace AzureUpdateTranslator.Server.Functions
{
    public class Orchestrator
    {
        [FunctionName("Orchestrator")]
        public static async Task<List<string>> RunOrchestrator(
           [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var input = context.GetInput<RequestDto>();

            var taskList = new List<Task<string>>();
            foreach (var url in input.Urls)
            {
                taskList.Add(context.CallActivityAsync<string>("ConvertToMDActivity", new ConvertToMDParam( url, input.NoTranslate)));
            }

            var list = (await Task.WhenAll(taskList)).ToList<string>();

            return list;
        }
    }
}
