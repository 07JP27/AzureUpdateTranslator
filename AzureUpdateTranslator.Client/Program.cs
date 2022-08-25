using System;
using System.Text;
using AzureUpdateTranslator.Share.Dtos;
using Newtonsoft.Json;

namespace AzureUpdateTranslator.Client
{
    public class Program
    {
        static async Task Main(string[] i_args)
        {
            CommandLine.ParserResult<Options> result = CommandLine.Parser.Default.ParseArguments<Options>(i_args);

            if (result.Tag == CommandLine.ParserResultType.Parsed)
            {
                var parsedOptions = (CommandLine.Parsed<Options>)result;

                var inputFilePath = parsedOptions.Value.InputFile;
                var noTranslation = parsedOptions.Value.NoTranslate;

                System.Console.WriteLine($"Input: {inputFilePath}");
                System.Console.WriteLine($"NoTranslate: {noTranslation}");

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

                System.Console.WriteLine($"Found {targetUrls.Count} URLs.");

                var requestDto = new RequestDto();
                requestDto.Urls = targetUrls;
                requestDto.NoTranslate = noTranslation;

                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("hogehoge", content);
                response.EnsureSuccessStatusCode();
                var checkStatus = JsonConvert.DeserializeObject<CheckStatusResponseDto>(await response.Content.ReadAsStringAsync());
            }

            System.Console.ReadKey();
        }
    }
}