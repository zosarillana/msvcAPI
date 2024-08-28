﻿using Restful_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restful_API
{
    public class MarketVisit
    {
        public int id { get; set; }

        [ForeignKey("User")] 
        public int user_id { get; set; }

        public string visit_date { get; set; } = string.Empty;

        [ForeignKey("Area")]
        public int area_id { get; set; }
        public string visit_accountName { get; set; } = string.Empty;
        public string visit_distributor { get; set; } = string.Empty;
        public string visit_salesPersonnel { get; set; } = string.Empty;
        public string visit_accountType { get; set; } = string.Empty;

        [ForeignKey("Isr")]
        public int isr_id { get; set; } 

        public string visit_isrNeed { get; set; } = string.Empty;
        public string visit_payolaSupervisor { get; set; } = string.Empty;
        public string visit_payolaMerchandiser { get; set; } = string.Empty;
        public string visit_averageOffTakePd { get; set; } = string.Empty;
        [ForeignKey("Pod")]
        public int pod_id { get; set; }
        public string visit_competitorsCheck { get; set; } = string.Empty;
        public string visit_pap { get; set; } = string.Empty;

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public MarketVisit()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }

        // Navigation property
        public User User { get; set; }
        public Isr Isr { get; set; }
        public Pod Pod { get; set; }
        public Area Area { get; set; }
    }
}
