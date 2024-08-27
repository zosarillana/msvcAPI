namespace Restful_API.DataTransferObject
{
    public class UpdateMarketVisitDto
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string visit_date { get; set; } = string.Empty;
        public string visit_area { get; set; } = string.Empty;
        public string visit_accountName { get; set; } = string.Empty;
        public string visit_distributor { get; set; } = string.Empty;
        public string visit_salesPersonnel { get; set; } = string.Empty;
        public string visit_accountType { get; set; } = string.Empty;
        public int isr_id { get; set; }
        public string visit_isrNeed { get; set; } = string.Empty;
        public string visit_payolaMerchandiser { get; set; } = string.Empty;
        public string visit_payolaSupervisor { get; set; } = string.Empty;
        public string visit_averageOffTakePd { get; set; } = string.Empty;
        public string visit_pod { get; set; } = string.Empty;
        public string visit_podMPP { get; set; } = string.Empty;
        public string visit_competitorsCheck { get; set; } = string.Empty;
        public string visit_pap { get; set; } = string.Empty;
    }
}
