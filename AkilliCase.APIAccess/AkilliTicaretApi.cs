using AkilliCase.APIAccess.ApiClient;
using AkilliCase.APIAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkilliCase.APIAccess
{
    public class AkilliTicaretApi
    {
        const string baseUrl = "https://api.akilliticaretim.com/api/";
        const string _loginPoint = "Auth/Login";
        private  string _productsPoint = "Product/ListProducts/0";

        private bool _result = false;

        private readonly RestClient _client;
        public AkilliTicaretApi()
        {
            _client = new RestClient(baseUrl);
        }


        private string restCall<T>(string uri, Method method, T model)
        {
            var req = new RestRequest(uri, method);
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("GUID", "0739-E657-C4F4-98B4");
            var reqBody = JsonConvert.SerializeObject(model);
            req.AddBody(reqBody, "application/json");

  
            return executeCall(req).Content;
        }

        private RestResponse executeCall(RestRequest req)
        {
            RestResponse response = _client.Execute(req);
            return response;
        }

        public bool loginAPI(loginModel user)
        {
            var test = restCall<loginModel>(_loginPoint, Method.Post, user);
            Response res = JsonConvert.DeserializeObject<Response>(test);

            if (res.status)
            {
                _result = true;
            }

            return _result;
        }
    }
}
