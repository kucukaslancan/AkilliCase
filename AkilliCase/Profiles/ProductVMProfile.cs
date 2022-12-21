using AkilliCase.ApiManager;
using AkilliCase.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.Profiles
{
    public class ProductVMProfile : Profile
    {
        public ProductVMProfile()
        {
            CreateMap<Product, ProductVM>();
        }
    }
}
