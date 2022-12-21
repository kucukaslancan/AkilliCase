using AkilliCase.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AkilliCase.ApiManager
{
    public class AkilliTicaretApi
    {
        const string baseUrl = "https://api.akilliticaretim.com/api/";
        const string _loginPoint = "Auth/Login";
        private string _productsPoint = "Product/ListProducts/0";
        private Tuple<bool, string> tuple;
        private bool _result = false;

        private readonly RestClient _client;
        public AkilliTicaretApi()
        {
            _client = new RestClient(baseUrl);
        }

        /*
         *  API erişimi
         * */
        public LoginResult Login(User user)
        {
            LoginResponse loginResponse = RestCall<User, LoginResponse>(_loginPoint, Method.Post, null, user);

            LoginResult result = new LoginResult();
            result.Result = loginResponse.status;

            if (!result.Result)
            {
                result.Message = "Kullanıcı Adı/Şifre Hatalı";
                return result;
            }

            result.Message = "Gırış başarılı";
            result.AuthToken = loginResponse.data.token;

            return result;
        }

        /*
         *  API üzerinden tüm ürünler
         * */
        public List<Product> GetAllProducts()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", SessionManager.authToken);
            var productReq = RestCall<object, ProductResponse>(_productsPoint, Method.Get, headers, null);

            return productReq.data;
        }

        /*
         *  Toplam ürün adeti
         */
        public int totalProductCount()
        {
            return this.GetAllProducts().Count;
        }

        // Rest dinamik çağrı
        private TResponse RestCall<TRequest, TResponse>(string uri, Method method, Dictionary<string, string> headers, TRequest request)
        {
            var req = new RestRequest(uri, method);
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("GUID", "0739-E657-C4F4-98B4");

            if (headers != null) //header varsa requeste headerları ekle
            {
                foreach (var header in headers)
                {
                    req.AddHeader(header.Key, header.Value);
                }
            }

            var reqBody = JsonConvert.SerializeObject(request);
            req.AddBody(reqBody, "application/json");


            var content = ExecuteCall(req).Content;
            TResponse response = JsonConvert.DeserializeObject<TResponse>(content);
            return response;
        }

        // Rest run 
        private RestResponse ExecuteCall(RestRequest req)
        {
            RestResponse response = _client.Execute(req);
            return response;
        }

        
    }
}
