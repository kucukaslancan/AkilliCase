
using System.Collections.Generic;

namespace AkilliCase.APIAccess.ApiClient
{
   public interface IApiService
    {
        T PostMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null);

        T GetMethod<T>(string uri, Dictionary<string, string> headers = null);

     
    }
}
