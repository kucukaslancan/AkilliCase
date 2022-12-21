using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.Models
{
    public class ProductVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string stockCode { get; set; }
        public int stock { get; set; }
        public double price { get; set; }
    }
}
