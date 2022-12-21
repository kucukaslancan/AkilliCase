using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.ApiManager
{
    public class Product
    {
            public int key { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string stockCode { get; set; }
            public int stock { get; set; }
            public double price { get; set; }
            public object priceVat { get; set; }
            public string stockType { get; set; }
            public string currency { get; set; }
            public int totalRow { get; set; }
            public double kdv { get; set; }
            public double listPrice { get; set; }
            public object listPriceVat { get; set; }
            public double unitIncrement { get; set; }
            public double discountRate { get; set; }
            public int isInFavorite { get; set; }
            public double maxSaleUnit { get; set; }
            public double minSaleUnit { get; set; }
            public int inCartQty { get; set; }
            public object prodImages { get; set; }

            public string detailBtn { get; set; }

    }
}
