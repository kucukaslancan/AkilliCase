using AkilliCase.ApiManager;
using AkilliCase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace AkilliCase.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AkilliTicaretApi _api;

        public LoginController(AkilliTicaretApi api)
        {
            _api = api;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult checkUser([FromBody] User user)
        {

            var loginResult = _api.Login(user);

            if (loginResult.Result)
            {
                SessionManager.authToken = loginResult.AuthToken;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username)
                };
                var idendity = new ClaimsIdentity(claims, loginResult.AuthToken);
                ClaimsPrincipal prin = new ClaimsPrincipal(idendity);
                HttpContext.SignInAsync(prin);
                HttpContext.Session.SetString("successToken", loginResult.AuthToken);
            }

            var result = new { Status = loginResult.Result, Message = loginResult.Message };
            return Json(result);
        }


    }
}
