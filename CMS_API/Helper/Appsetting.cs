using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Helper
{
    public class Appsetting
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public double accessExpiration { get; set; }
        public double refreshExpiration { get; set; }
    }
}
