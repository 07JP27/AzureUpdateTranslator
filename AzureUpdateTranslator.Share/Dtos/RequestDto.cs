using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class RequestDto
    {
        public List<RequestItem> Items { get; set; } = new List<RequestItem>();
    }
}
