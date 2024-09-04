namespace Restful_API.DataTransferObject
{
    public class UpdateMarketVisitDto
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string visit_date { get; set; } = string.Empty;
        public int area_id { get; set; }
        public string visit_accountName { get; set; } = string.Empty;
        public string visit_distributor { get; set; } = string.Empty;
        public string visit_salesPersonnel { get; set; } = string.Empty;
        public string visit_accountType { get; set; } = string.Empty;
        public int isr_id { get; set; } // Ensure this is of type int     
        public string isr_reqOthers { get; set; } = string.Empty;
        public string isr_req_ImgPath { get; set; } = string.Empty;
        public string isr_needsOthers { get; set; } = string.Empty;
        public string isr_needs_ImgPath { get; set; } = string.Empty;
        public string visit_payolaSupervisor { get; set; } = string.Empty;
        public string visit_payolaMerchandiser { get; set; } = string.Empty;
        public string visit_averageOffTakePd { get; set; } = string.Empty;
        public int pod_id { get; set; }
        public string pod_canned_other { get; set; } = string.Empty;
        public string pod_mpp_other { get; set; } = string.Empty;
        public string visit_competitorsCheck { get; set; } = string.Empty;
        public int pap_id { get; set; }
        public string pap_others { get; set; } = string.Empty;
    }
}
