using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.ApiManager
{
    public class ProductResponse
    {
        public bool status { get; set; }
        public List<Product> data { get; set; }
    }
}
