using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.ApiManager
{
    public class LoginResponse
    {
        public bool status { get; set; }
        public TokenData data { get; set; }
    }
}
