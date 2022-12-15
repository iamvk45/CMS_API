using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_API_BO
{
    public class Login
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ResetPassword : Login
    {
        public string Type { get; set; }
    }
    public class UserModelSession
    {
        public string PartyId { get; set; }
        public string Hirarchy { get; set; }
        public string Type { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string ServicesCollection { get; set; }
        public string IsActive { get; set; }
        public string PartialOrderID { get; set; }
        public string RegistrationNo { get; set; }
        public string profileImage { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyType { get; set; }
        public double CashInWallet { get; set; }
        public double CashOutWallet { get; set; }
        public double UseableAmtWallet { get; set; }
        public double PendingTransationinQueyWallet { get; set; }
    }
}
