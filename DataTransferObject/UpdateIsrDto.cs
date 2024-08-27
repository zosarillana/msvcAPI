using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class UpdateIsrDto
    {
        public int id { get; set; }     
        public string isr_name { get; set; } = string.Empty;   
        public string isr_type { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
