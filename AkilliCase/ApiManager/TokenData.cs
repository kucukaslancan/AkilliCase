using System;

namespace AkilliCase.ApiManager
{
    public class TokenData
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime expiration { get; set; }
        public object error { get; set; }
        public bool status { get; set; }
    }
}
