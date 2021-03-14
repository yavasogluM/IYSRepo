using System;
using System.Threading.Tasks;
using IYS.Bridge.Models;

namespace IYS.Bridge
{
    public interface IPermissionHelper
    {
        Task<Models.PermissionResponseModel> CheckEmailPermissionAsync(string recipient, string recipientType, Models.TokenResponseModel tokenResponseModel);
        Task<PermissionResponseModel> CheckEmailPermissionAsync(string recipient, string recipientType, string iysCode, string tokenType, string token);
    }

    public class PermissionHelper : IPermissionHelper
    {
        private readonly string PermissionCheckUrl;
        private readonly Models.IYSConfigModel _iysConfigModel;
        private readonly Helper.IWebClientHelper _webClientHelper;

        public PermissionHelper(Models.IYSConfigModel iysConfigModel)
        {
            _iysConfigModel = iysConfigModel;
            PermissionCheckUrl = $"{_iysConfigModel.BaseUrl}/sps/{_iysConfigModel.IYSCode}/brands/{_iysConfigModel.BrandCode}/consents/status";
            _webClientHelper = new Helper.WebClientHelper();
        }


        public async Task<PermissionResponseModel> CheckEmailPermissionAsync(string recipient, string recipientType, TokenResponseModel tokenResponseModel)
        {
            try
            {
                var PostRequestResult = await _webClientHelper.DoPostRequestAsync<Models.PermissionResponseModel, Models.PermissionRequestModel>(new PermissionRequestModel
                {
                    recipient = recipient,
                    recipientType = recipientType, //TACIR, BIREYSEL
                    type = "EPOSTA"
                }, PermissionCheckUrl, false, true, tokenResponseModel.token_type, tokenResponseModel.access_token);
                return PostRequestResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<PermissionResponseModel> CheckEmailPermissionAsync(string recipient, string recipientType, string iysCode, string tokenType, string token)
        {
            try
            {
                string url = $"{_iysConfigModel.BaseUrl}/sps/{iysCode}/brands/{iysCode}/consents/status";
                var PostRequestResult = await _webClientHelper.DoPostRequestAsync<Models.PermissionResponseModel, Models.PermissionRequestModel>(new PermissionRequestModel
                {
                    recipient = recipient,
                    recipientType = recipientType, //TACIR, BIREYSEL
                    type = "EPOSTA"
                }, url, false, true, tokenType, token);
                return PostRequestResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
