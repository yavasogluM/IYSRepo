using System;
namespace IYS.Bridge.Models
{
    public class IYSConfigModel
    {
        public string BaseUrl { get; set; }
        public string PasswordGrantType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IYSCode { get; set; }
        public string BrandCode { get; set; }
    }
}
