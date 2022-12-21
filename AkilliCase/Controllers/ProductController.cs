using AkilliCase.ApiManager;
using AkilliCase.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliCase.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        AkilliTicaretApi _api;
        private readonly IMapper _mapper;
        public ProductController(AkilliTicaretApi api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getAllProduct()
        {
            List<Product> products = _api.GetAllProducts();
            List<ProductVM> productVM = _mapper.Map<List<ProductVM>>(products);

            return Json(productVM);
        }
    }
}
