using CMS_API_BO;
using CMS_API_DL;
using System.Collections.Generic;

namespace CMS_API_BL
{
    public class CommonBL
    {
        CommonDL common = new CommonDL();
        public List<Dropdown> GetDropdownData(int Enumno = 0)
        {
            return common.GetDropdownData(Enumno);
        }
        public API_Common_Res SaveContentData(ContentPage content)
        {
            return common.SaveContentData(content);
        }
        public API_Common_Res EditContentData(ContentPage content)
        {
            return common.EditContentData(content);
        }

        public API_Common_Res Admin_News_Announcement_Save(NEWANNMST master)
        {
            return common.Admin_News_Announcement_Save(master);
        }
        public List<NEWANNMST> Admin_News_Announcement_Show(int Type, int ShowType)
        {
            return common.Admin_News_Announcement_Show(Type, ShowType);
        }

        public API_Common_Res GetData(string Type, string MenuId, string PartyId)
        {
            return common.GetData(Type, MenuId, PartyId);
        }
    }
}
