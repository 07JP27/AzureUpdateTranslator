using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureUpdateTranslator.Share.Dtos
{
    public class CheckStatusResponseDto
    {
        public string Id { get; set; } = string.Empty;
        public string StatusQueryGetUri { get; set; } = string.Empty;
    }
}
