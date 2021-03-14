using System;
using System.Threading.Tasks;
using Xunit;

namespace IYS.Tests
{
    public class IYSApiTests
    {
        private Bridge.Models.IYSConfigModel IYSConfigModel
        {
            get
            {
                return new Bridge.Models.IYSConfigModel
                {
                    BaseUrl = "https://api.iys.org.tr",
                    PasswordGrantType = "password",
                    UserName = "",
                    Password = "",
                    IYSCode = "",
                    BrandCode = ""
                };
            }
        }

        [Fact]
        public void LoginTest()
        {
            Bridge.Models.IYSConfigModel iysConfig = IYSConfigModel;
            Bridge.ILoginHelper loginHelper = new Bridge.LoginHelper(iysConfig);
            var token = loginHelper.GetTokenAsync().Result;
            Assert.NotNull(token);
        }

        [Theory]
        [InlineData("bireyselmail@domain.com", "BIREYSEL")]
        [InlineData("ticarimail@domain.com", "TACIR")]
        public void PermissionTest(string email, string mailtype)
        {
            Bridge.Models.IYSConfigModel iysConfig = IYSConfigModel;

            Bridge.ILoginHelper loginHelper = new Bridge.LoginHelper(iysConfig);
            var token = loginHelper.GetTokenAsync().Result;

            Bridge.IPermissionHelper permissionHelper = new Bridge.PermissionHelper(iysConfig);
            var userData = permissionHelper.CheckEmailPermissionAsync(email, mailtype, token).Result;
            Assert.NotNull(userData);
        }
    }
}
