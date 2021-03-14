using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IYS.WebUI.Models;

namespace IYS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IYS.Bridge.ILoginHelper _loginHelper;
        private readonly IYS.Bridge.IPermissionHelper _permissionHelper;

        public HomeController(
            ILogger<HomeController> logger,
            IYS.Bridge.ILoginHelper loginHelper,
            IYS.Bridge.IPermissionHelper permissionHelper
            )
        {
            _logger = logger;
            _loginHelper = loginHelper;
            _permissionHelper = permissionHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var token = await _loginHelper.GetTokenAsync(password, username);
            Models.TokenViewModel tokenViewModel = new TokenViewModel { AccessToken = token.access_token, ExpiredAt = token.TokenExpiredAt , TokenType = token.token_type };
            return View(tokenViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> CheckUserPermission([FromBody]Models.PermissionCheckModel model)
        {

            try
            {
                var result = await _permissionHelper.CheckEmailPermissionAsync(model.email, model.type, model.iyscode, model.tokentype, model.token);

                return Json(new { result = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.ToString() });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
