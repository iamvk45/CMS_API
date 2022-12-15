using CMS_API.Helper;
using CMS_API_BL;
using CMS_API_BO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        AuthBL authBL = new AuthBL();
    
        [HttpPost]
        [Route("Login")]
        public API_Common_Res Login(Login login)
        {
            var objAPI_Common_Res = authBL.Login(login);

            if (objAPI_Common_Res.Data != null)
            {
                var objModel = JsonConvert.DeserializeObject<UserModelSession>(objAPI_Common_Res.Data.NulllToString());

                var jwtstring = GetSettings.JWT_GetToken(objModel.Username);

                objAPI_Common_Res.JWT = jwtstring;
            }
            return objAPI_Common_Res;

        }

        [HttpPost]
        [Route("ResetPassword")]
        public API_Common_Res Reset(ResetPassword reset)
        {
            var objAPI_Common_Res = authBL.ResetPassword(reset);
            return objAPI_Common_Res;
        }
    }
}
