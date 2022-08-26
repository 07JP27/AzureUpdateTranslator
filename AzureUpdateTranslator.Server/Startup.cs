using System;
using AzureUpdateTranslator.Server;
using DeepL;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureUpdateTranslator.Server
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var deeplAuthKey = Environment.GetEnvironmentVariable("DeeplAuthKey");
            var deeplOnption = new TranslatorOptions() { 
                MaximumNetworkRetries = 3,
            };
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<Translator>(
                service => new Translator(deeplAuthKey, deeplOnption)
            );
        }
    }
}
