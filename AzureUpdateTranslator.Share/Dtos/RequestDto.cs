using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class RequestDto
    {
        public List<string> Urls { get; set; } = new List<string>();
        public bool NoTranslate { get; set; } = false;
    }
}
