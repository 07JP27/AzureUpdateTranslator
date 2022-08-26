using AzureUpdateTranslator.Share.Constants;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class RequestDto
    {
        public List<string> Urls { get; set; } = new List<string>();
        public bool NoTranslate { get; set; } = false;
        public string Translator { get; set; } = TranslatorOption.DeepL;
    }
}
