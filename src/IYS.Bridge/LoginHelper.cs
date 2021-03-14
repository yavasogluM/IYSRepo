using System;
using System.Threading.Tasks;
using IYS.Bridge.Models;

namespace IYS.Bridge
{
    public interface ILoginHelper
    {
        Task<Models.TokenResponseModel> GetTokenAsync();
        Task<Models.TokenResponseModel> GetTokenAsync(string password, string username);
    }
    public class LoginHelper : ILoginHelper
    {
        private readonly string LoginEndPointUrl;
        private readonly Models.IYSConfigModel _iysConfigModel;
        private readonly Helper.IWebClientHelper _webClientHelper;


        public LoginHelper(Models.IYSConfigModel iysConfigModel)
        {
            _iysConfigModel = iysConfigModel;
            LoginEndPointUrl = $"{_iysConfigModel.BaseUrl}/oauth2/token";
            _webClientHelper = new Helper.WebClientHelper();
        }

        public async Task<TokenResponseModel> GetTokenAsync()
        {
            try
            {
                Models.TokenRequestModel tokenRequestObject = new TokenRequestModel
                {
                    grant_type = _iysConfigModel.PasswordGrantType,
                    password = _iysConfigModel.Password,
                    username = _iysConfigModel.UserName
                };

                return await _webClientHelper.DoPostRequestAsync<Models.TokenResponseModel, Models.TokenRequestModel>(tokenRequestObject, LoginEndPointUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TokenResponseModel> GetTokenAsync(string password, string username)
        {
            try
            {
                Models.TokenRequestModel tokenRequestObject = new TokenRequestModel
                {
                    grant_type = _iysConfigModel.PasswordGrantType,
                    password = password,
                    username = username
                };

                return await _webClientHelper.DoPostRequestAsync<Models.TokenResponseModel, Models.TokenRequestModel>(tokenRequestObject, LoginEndPointUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
