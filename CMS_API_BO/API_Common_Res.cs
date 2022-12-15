using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_API_BO
{
    public class API_Common_Res
    {
        public string ResponseCode { get; set; }
        public int statusCode { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int ID { get; set; }
        public object Data { get; set; }
        public string Body { get; set; }
        public string JWT { get; set; }
        public string RegistrationId { get; set; }
    }
}
