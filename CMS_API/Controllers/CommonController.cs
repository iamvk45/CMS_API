using CMS_API_BL;
using CMS_API_BO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : Controller
    {
        CommonBL commonBL = new CommonBL();

        API_Common_Res common_Res = new API_Common_Res();

        //[Authorize]
        [HttpPost]
        [Route("SaveContentData")]
        public API_Common_Res SaveContentData(ContentPage content)
        {
            try
            {
                var objAPI_Common_Res = commonBL.SaveContentData(content);
                return objAPI_Common_Res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("EditContentData")]
        public API_Common_Res EditContentData(ContentPage content)
        {
            try
            {
                var objAPI_Common_Res = commonBL.EditContentData(content);
                return objAPI_Common_Res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Admin_News_Announcement_Save")]
        public API_Common_Res Admin_News_Announcement_Save(NEWANNMST master)
        {
            common_Res = commonBL.Admin_News_Announcement_Save(master);
            if (common_Res.statusCode == 1 || common_Res.statusCode == 0)
            {

                common_Res.ResponseCode = "000";
                common_Res.Message = common_Res.Message;
                common_Res.statusCode = common_Res.statusCode;

            }
            else
            {

                common_Res.ResponseCode = "001";
                common_Res.Message = common_Res.Message;
                common_Res.statusCode = 0;
            }


            return common_Res;

        }

        [HttpGet]
        [Route("Admin_News_Announcement_Show")]
        public API_Common_Res Admin_News_Announcement_Show(int Type, int ShowType)
        {
            List<NEWANNMST> ListRequest = new List<NEWANNMST>();
            ListRequest = commonBL.Admin_News_Announcement_Show(Type, ShowType);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                common_Res.Data = ListRequest;
                //objResponseData.Body = raw;
                common_Res.ResponseCode = "000";
                common_Res.Message = "News and Announcement List";
                common_Res.statusCode = 1;
            }
            else
            {

                common_Res.Data = null;
                common_Res.ResponseCode = "000";
                common_Res.Message = "Data Not Available";
                common_Res.statusCode = 0;

            }

            return common_Res;
        }

        [HttpPost]
        [Route("GetData")]
        public API_Common_Res GetData(string Type, string MenuId, string PartyId = null)
        {
            try
            {
                var objResponseData = commonBL.GetData(Type, MenuId, PartyId);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
