using CMS_API_BO;
using CMS_API_DL;

namespace CMS_API_BL
{
    public class AuthBL
    {
        AuthDL authDL = new AuthDL();
        public API_Common_Res Login(Login login)
        {
            return authDL.Login(login);
        }
        public API_Common_Res ResetPassword(ResetPassword reset)
        {
            return authDL.ResetPassword(reset);
        }
    }
}
