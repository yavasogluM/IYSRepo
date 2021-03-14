using System;
using System.Net;
using System.Threading.Tasks;

namespace IYS.Helper
{
    public interface IWebClientHelper
    {
        Task<Y> DoPostRequestAsync<Y, T>(T Model, string RequestUrl, bool TlsUse = false,  bool WithAuthorization = false, string TokenType = "", string AuthToken = "") where Y : class;

        Task<T> DoGetRequestAsync<T>(string RequestUrl, bool TlsUse = false, bool WithAuthorization = false, string TokenType = "", string AuthToken = "") where T : class;
    }

    public class WebClientHelper : IWebClientHelper
    {
        public async Task<Y> DoPostRequestAsync<Y, T>(T Model, string RequestUrl, bool TlsUse = false, bool WithAuthorization = false, string TokenType = "", string AuthToken = "") where Y : class
        {
            using(WebClient webClient = new WebClient())
            {
                if (TlsUse)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                }

                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=utf-8"); //it will be change!

                if (WithAuthorization)
                {
                    TokenType = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TokenType);
                    webClient.Headers.Add(HttpRequestHeader.Authorization, $"{TokenType} {AuthToken}");
                }

                string PostData = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
                string result = await webClient.UploadStringTaskAsync(RequestUrl, "POST", PostData);

                return Newtonsoft.Json.JsonConvert.DeserializeObject<Y>(result);
            }
        }

        public async Task<T> DoGetRequestAsync<T>(string RequestUrl, bool TlsUse = false, bool WithAuthorization = false, string TokenType = "", string AuthToken = "") where T : class
        {
            using(WebClient webClient = new WebClient())
            {
                if (TlsUse)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                }

                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=utf-8"); //it will be change!

                if (WithAuthorization)
                {
                    TokenType = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TokenType);
                    webClient.Headers.Add(HttpRequestHeader.Authorization, $"{TokenType} {AuthToken}");
                }


                string result = await webClient.DownloadStringTaskAsync(RequestUrl);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
