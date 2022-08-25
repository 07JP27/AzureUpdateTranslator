using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class StatusResponseDto
    {
        public string RuntimeStatus { get; set; } = string.Empty;
        public List<string> Output { get; set; } = new List<string>();
    }
}
