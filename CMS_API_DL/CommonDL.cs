using CMS_API_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CMS_API_DL
{
    public class CommonDL
    {
        API_Common_Res objAPI_Common_Res = new API_Common_Res();
        string connectionString = DBCS.GetConnectionString();
        public List<Dropdown> GetDropdownData(int Enumno)
        {
            List<Dropdown> objListdoc = new List<Dropdown>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@EnumNo", Enumno);
                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_ADMIN_CustomFieldsByEnumNo_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown objdoc = new Dropdown();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : CommonDL / Function : GetCustomList", connectionString);
            }
            return objListdoc;
        }
        public API_Common_Res SaveContentData(ContentPage content)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@PageTitle", content.PageTitle);
                param[1] = new SqlParameter("@PageImage", content.PageImage);
                param[2] = new SqlParameter("@PageKeywords", content.PageKeywords);
                param[3] = new SqlParameter("@MetaDescription", content.MetaDescription);
                param[4] = new SqlParameter("@PageContent", content.PageContent);
                param[5] = new SqlParameter("@PageURL", content.PageURL);
                param[6] = new SqlParameter("@enumId", content.EnumId);
                param[7] = new SqlParameter("@createdBy", "Admin");

                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_ADMIN_PageTemplate_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objAPI_Common_Res.ResponseCode = "000";
                    objAPI_Common_Res.Message = "Content Saved...";
                    objAPI_Common_Res.statusCode = 1;
                }
                else
                {
                    objAPI_Common_Res.ResponseCode = "001";
                    objAPI_Common_Res.Message = "No Data Available...";
                    objAPI_Common_Res.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : CommonDL / Function : SaveContentData", connectionString);
            }
            return objAPI_Common_Res;
        }
        public API_Common_Res EditContentData(ContentPage content)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@type", content.Type);
                param[1] = new SqlParameter("@id", content.Id);
                param[2] = new SqlParameter("@Content", content.PageContent == null ? "" : content.PageContent.TrimStart());
                param[3] = new SqlParameter("@updatedBy", "Admin");

                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_ADMIN_PageTemplate_UpdateView]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objAPI_Common_Res.ResponseCode = "000";
                    objAPI_Common_Res.Message = "Content Updated Successfully...";
                    objAPI_Common_Res.statusCode = 1;
                    objAPI_Common_Res.Data = ds.Tables[0];
                }
                else
                {
                    objAPI_Common_Res.ResponseCode = "001";
                    objAPI_Common_Res.Message = "No Data Available...";
                    objAPI_Common_Res.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : CommonDL / Function : EditContentData", connectionString);
            }
            return objAPI_Common_Res;
        }
        public API_Common_Res Admin_News_Announcement_Save(NEWANNMST master)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@iSts", master.iSts);
                param[1] = new SqlParameter("@iPK_NewId", master.iPK_NewId);
                param[2] = new SqlParameter("@iNwsAnnoType", master.iNwsAnnoType);
                param[3] = new SqlParameter("@dtSrtDt", master.dtSrtDt);
                param[4] = new SqlParameter("@dtEndDt", master.dtEndDt);
                param[5] = new SqlParameter("@dFrmTime", master.dFrmTime);
                param[6] = new SqlParameter("@dToTime", master.dToTime);
                param[7] = new SqlParameter("@sMsg", master.sMsg);
                param[8] = new SqlParameter("@sPatyCode", master.sPatyCode);
                param[9] = new SqlParameter("@sSubject", master.sSubject);

                DataTable DT = DBOperation.FillDataTable("[dbo].[Usp_Admin_News_Announcement_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objAPI_Common_Res.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objAPI_Common_Res.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objAPI_Common_Res.statusCode = 0;
                    objAPI_Common_Res.Message = "Failed";
                }
            }
            catch (Exception ex)
            {
                objAPI_Common_Res.statusCode = 0;
                objAPI_Common_Res.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(ex, 0, "Class : CommonDL / Function : Admin_News_Announcement_Save");
            }
            return objAPI_Common_Res;

        }
        public List<NEWANNMST> Admin_News_Announcement_Show(int Type, int ShowType)
        {
            List<NEWANNMST> objListdoc = new List<NEWANNMST>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", Type);
                param[1] = new SqlParameter("@ShowType", ShowType);
                DataSet ds = DBOperation.FillDataSet("[dbo].[Usp_Admin_News_Announcement_Show]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<NEWANNMST>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        NEWANNMST objdoc = new NEWANNMST();
                        objdoc.iPK_NewId = ds.Tables[0].Rows[i]["iPK_NewId"].NulllToInt();
                        objdoc.iNwsAnnoType = ds.Tables[0].Rows[i]["iNwsAnnoType"].NulllToInt();
                        objdoc.iSts = ds.Tables[0].Rows[i]["iSts"].NulllToInt();
                        objdoc.dtSrtDt = ((DateTime)ds.Tables[0].Rows[i]["dtSrtDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                        objdoc.dtEndDt = ((DateTime)ds.Tables[0].Rows[i]["dtEndDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                        objdoc.dFrmTime = ds.Tables[0].Rows[i]["dFrmTime"].NulllToString();
                        objdoc.dToTime = ds.Tables[0].Rows[i]["dToTime"].NulllToString();
                        objdoc.sSubject = ds.Tables[0].Rows[i]["sSubject"].NulllToString();
                        objdoc.sMsg = ds.Tables[0].Rows[i]["sMsg"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }

            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Admin_News_Announcement_Show");
            }
            return objListdoc;
        }

        public API_Common_Res GetData(string Type, string MenuId, string partyid)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@type", Type);
                param[1] = new SqlParameter("@menuId", MenuId);
                param[2] = new SqlParameter("@PartyId", partyid);

                DataSet ds = DBOperation.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    objAPI_Common_Res.ResponseCode = "000";
                    objAPI_Common_Res.Data = ds.Tables[0];
                    objAPI_Common_Res.Message = "Data Fetched Successfully...!";
                    objAPI_Common_Res.statusCode = 1;
                }
                else
                {
                    objAPI_Common_Res.ResponseCode = "001";
                    objAPI_Common_Res.Message = "No Data Available...";
                    objAPI_Common_Res.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : CommonDL / Function : GetData", connectionString);
            }
            return objAPI_Common_Res;
        }
    }
}
