using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Server.Models
{
    public class ConvertToMDParam
    {
        public string Url { get; private set; }
        public bool NoTranslate { get; private set; }

        public ConvertToMDParam(string url, bool noTranslate)
        {
            this.Url = url;
            this.NoTranslate = noTranslate;
        }
    }
}
