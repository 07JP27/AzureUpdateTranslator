namespace AzureUpdateTranslator.Server.Models
{
    public class ConvertToMDParam
    {
        public string Url { get; private set; }
        public bool NoTranslate { get; private set; }
        public string Translator { get; private set; }

        public ConvertToMDParam(string url, bool noTranslate, string translator)
        {
            this.Url = url;
            this.NoTranslate = noTranslate;
            this.Translator = translator;
        }
    }
}
