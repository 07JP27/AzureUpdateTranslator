namespace AzureUpdateTranslator.Client
{
    public class Options
    {
        [CommandLine.Option('f', "file", Required = true, HelpText = "Target URL CSV file path.")]
        public string InputFile
        {
            get;
            set;
        } = string.Empty;

        [CommandLine.Option('n', "no-translate", Required = false, HelpText = "Add if generate in original language.")]
        public bool NoTranslate
        {
            get;
            set;
        } = false;

        [CommandLine.Option('c', "cognitive", Required = false, HelpText = "Add if use Cognitive service as translation engine.(Default engine:DeepL)")]
        public bool UseCognitive
        {
            get;
            set;
        } = false;
    }
}
