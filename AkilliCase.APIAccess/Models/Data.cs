using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkilliCase.APIAccess.Models
{
   public class Data
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime expiration { get; set; }
        public object error { get; set; }
        public bool status { get; set; }
    }
}
