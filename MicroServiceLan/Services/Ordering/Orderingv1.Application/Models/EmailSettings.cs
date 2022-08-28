using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderingv1.Application.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
