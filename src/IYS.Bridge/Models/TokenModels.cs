using System;
namespace IYS.Bridge.Models
{
    public class TokenRequestModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
    }

    public class TokenResponseModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string token_type { get; set; }
        public DateTime TokenExpiredAt => DateTime.Now.AddSeconds(expires_in);
    }
}
