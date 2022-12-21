
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace AkilliCase.APIAccess.ApiClient
{
    public class ApiService : IApiService
    {
        public T GetMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.Get.ToString()) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        public T PostMethod<T>(object requestObj, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.Post.ToString()) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, requestObj, headers);

            return result;
        }

      

        private T GetResult<T>(RestClient client, RestRequest request, object requestObject = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}
