using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class IsrDto
    {
     
        public int id { get; set; }

       
   
        public string isr_name { get; set; } = string.Empty;
      
        public string isr_others { get; set; } = string.Empty;
      
        public string isr_type { get; set; } = string.Empty;
       
        public string description { get; set; } = string.Empty;
       
        public string image_path { get; set; } = string.Empty;
    }
}
