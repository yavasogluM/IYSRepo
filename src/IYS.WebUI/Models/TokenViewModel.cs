using System;
namespace IYS.WebUI.Models
{
    public class TokenViewModel
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }

    public class PermissionCheckModel
    {
        public string tokentype { get; set; }
        public string token { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string iyscode { get; set; }
    }
}
