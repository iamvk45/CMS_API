using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_API_BO
{
    public class NEWANNMST
    {
        public int? iPK_NewId { get; set; }
        public int iSts { get; set; }
        public string dtCrtDt { get; set; }
        public string dtSrtDt { get; set; }
        public string dtEndDt { get; set; }
        public int iNwsAnnoType { get; set; }
        public string sPatyCode { get; set; }
        public string sMsg { get; set; }
        public string sSubject { get; set; }
        public string dFrmTime { get; set; }

        public string dToTime { get; set; }
    }

}
