using System.Collections.Immutable;
using System.Text;
using AzureUpdateTranslator.Share.Constants;
using AzureUpdateTranslator.Share.Dtos;
using Newtonsoft.Json;

namespace AzureUpdateTranslator.Client
{
    public class Program
    {
        private const int POLLING_INTERVAL = 5000;
        private const string ENDPOINT = "http://localhost:7004/api/starter";

        static async Task Main(string[] i_args)
        {
            CommandLine.ParserResult<Options> result = CommandLine.Parser.Default.ParseArguments<Options>(i_args);

            if (result.Tag == CommandLine.ParserResultType.Parsed)
            {
                var parsedOptions = (CommandLine.Parsed<Options>)result;

                var inputFilePath = parsedOptions.Value.InputFile;
                var noTranslation = parsedOptions.Value.NoTranslate;
                var useCognitive = parsedOptions.Value.UseCognitive;

                System.Console.WriteLine($"Target file: {inputFilePath}");
                System.Console.WriteLine($"NoTranslate: {noTranslation}");
                if(!noTranslation)
                {
                    var translatorLabel = useCognitive ? "Cognitive" : "DeepL";
                    System.Console.WriteLine($"Translator:{translatorLabel}");
                }

                List<string> targetUrls = new List<string>();

                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();
                        if (line == null) continue;
                        targetUrls.Add(line.Split(',')[0]);
                    }
                }

                System.Console.WriteLine($"{targetUrls.Count} URLs found.");

                var requestDto = new RequestDto();
                requestDto.Urls = targetUrls;
                requestDto.NoTranslate = noTranslation;
                requestDto.Translator = useCognitive ? TranslatorOption.Cognitive : TranslatorOption.DeepL;

                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(ENDPOINT, content);
                response.EnsureSuccessStatusCode();
                var checkStatus = JsonConvert.DeserializeObject<CheckStatusResponseDto>(await response.Content.ReadAsStringAsync());
                Console.WriteLine($"StatusURL:{checkStatus.StatusQueryGetUri}");

                var loopCondition = ImmutableList.Create("Pending", "Running");
                StatusResponseDto status;

                while (true)
                {
                    var statusRes = await client.GetAsync(checkStatus.StatusQueryGetUri + "&showInput=false");
                    status = JsonConvert.DeserializeObject<StatusResponseDto>(await statusRes.Content.ReadAsStringAsync());
                    Console.WriteLine($"Status:{status.RuntimeStatus}");

                    if (!loopCondition.Contains(status.RuntimeStatus)) break;
                    await Task.Delay(POLLING_INTERVAL);
                }
                
                if(status.RuntimeStatus == "Completed")
                {
                    using (StreamWriter writer = new StreamWriter("output.md", false))
                    {
                        foreach(var topic in status.Output)
                        {
                            await writer.WriteAsync(topic);
                            await writer.WriteAsync(Environment.NewLine + "---" + Environment.NewLine + Environment.NewLine);
                        }
                    }

                    Console.WriteLine($"Completed");
                }
                else
                {
                    Console.Error.WriteLine(status.Output);
                }
               
            }

            System.Console.ReadKey();
        }
    }
}