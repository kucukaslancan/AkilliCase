using AkilliCase.ApiManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkilliCase.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AkilliTicaretApi _api;

        public HomeController(AkilliTicaretApi api)
        {
            this._api = api;
        }

        public IActionResult Index()
        {
            int totalProductCount = _api.totalProductCount();
            ViewData["totalProduct"] = totalProductCount;

            return View();
        }
    }
}
