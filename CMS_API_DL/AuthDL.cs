using CMS_API_BO;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CMS_API_DL
{
    public class AuthDL
    {
        API_Common_Res objAPI_Common_Res = new API_Common_Res();
        string connectionString = DBCS.GetConnectionString();
        public API_Common_Res Login(Login login)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@EmailId", login.Email);
                param[1] = new SqlParameter("@Passwordstr", Cryptography.Encrypt(login.Password));
                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_MASTER_UserLoginCheck_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objAPI_Common_Res.ResponseCode = "000";
                    objAPI_Common_Res.Message = "User Details";
                    objAPI_Common_Res.Data = JObject.FromObject(new UserModelSession
                    {
                        EmailId = ds.Tables[0].Rows[0]["sEmailId"].NulllToString(),
                        MobileNumber = ds.Tables[0].Rows[0]["sMobileNo"].NulllToString(),
                        PartyId = ds.Tables[0].Rows[0]["sPK_PrtyCode"].NulllToString(),
                        ServicesCollection = ds.Tables[0].Rows[0]["sSrvicC"].NulllToString(),
                        Type = ds.Tables[0].Rows[0]["iTyp"].NulllToString(),
                        Username = ds.Tables[0].Rows[0]["Username"].NulllToString(),
                        IsActive = ds.Tables[0].Rows[0]["IsActive"].NulllToString(),
                        //PartialOrderID = ds.Tables[0].Rows[0]["PartialOrderID"].NulllToString(),
                        RegistrationNo = ds.Tables[0].Rows[0]["sRegNo"].NulllToString(),
                        //profileImage = ds.Tables[0].Rows[0]["profileImage"].NulllToString(),
                        RoleId = ds.Tables[0].Rows[0]["iRoleId"].NulllToInt(),
                        DepartmentId = ds.Tables[0].Rows[0]["iDeptId"].NulllToInt(),
                        Hirarchy = ds.Tables[0].Rows[0]["sHirarchy"].NulllToString(),
                        //UserType = ds.Tables[0].Rows[0]["UserType"].NulllToString(),
                        CompanyType = ds.Tables[0].Rows[0]["iCmpnyId"].NulllToInt(),
                        //CashInWallet = ds.Tables[1].Rows[0]["CashInWallet"].NulllToDouble(),
                        //CashOutWallet = ds.Tables[2].Rows[0]["CashOutWallet"].NulllToDouble(),
                        //UseableAmtWallet = ds.Tables[3].Rows[0]["UseableAmtWallet"].NulllToDouble(),
                        //PendingTransationinQueyWallet = ds.Tables[4].Rows[0]["PendingTransationinQueyWallet"].NulllToDouble()
                    });
                    objAPI_Common_Res.statusCode = 1;
                }
                else
                {
                    objAPI_Common_Res.ResponseCode = "001";
                    objAPI_Common_Res.Message = "User Details Not Found...";
                    objAPI_Common_Res.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AuthDL / Function : Login", connectionString);
            }
            return objAPI_Common_Res;
        }
        public API_Common_Res ResetPassword(ResetPassword resetpassword)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@email", resetpassword.Email);
                param[1] = new SqlParameter("@password", Cryptography.Encrypt(resetpassword.Password));
                param[2] = new SqlParameter("@type", resetpassword.Type);
                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_ADMIN_ResetUsersPassword_SelectUpdate]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objAPI_Common_Res.ResponseCode = "000";
                    objAPI_Common_Res.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objAPI_Common_Res.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objAPI_Common_Res.ResponseCode = "001";
                    objAPI_Common_Res.Message = "Not Saved...";
                    objAPI_Common_Res.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AuthDL / Function : ResetPassword", connectionString);
            }
            return objAPI_Common_Res;
        }
    }
}
