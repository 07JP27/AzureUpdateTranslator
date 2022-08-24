using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class RequestItemDto
    {
        public string Url { get; set; } = string.Empty;
        public bool DoTranslate { get; set; } = true;
    }
}
