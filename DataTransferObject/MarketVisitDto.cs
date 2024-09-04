namespace Restful_API.DataTransferObject
{
    public class MarketVisitDto
    {
    public int user_id { get; set; }
    public string visit_date { get; set; }
    public int area_id { get; set; }
    public string visit_accountName { get; set; }
    public string visit_distributor { get; set; }
    public string visit_salesPersonnel { get; set; }
    public string visit_accountType { get; set; }
    public int isr_id { get; set; }
    public string isr_reqOthers { get; set; }
    public string isr_needsOthers { get; set; }    
    public string visit_payolaSupervisor { get; set; }
    public string visit_payolaMerchandiser { get; set; }
    public string visit_averageOffTakePd { get; set; }
    public int pod_id { get; set; }
    public string visit_competitorsCheck { get; set; }
    public int pap_id { get; set; }
    public IFormFile file { get; set; }
    public IFormFile file2 { get; set; }

    }


}
