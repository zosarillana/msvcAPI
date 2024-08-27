using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class CreatePodDto
    {       
        public int id { get; set; }     
        public string pod_name { get; set; } = string.Empty;       
        public string pod_others { get; set; } = string.Empty;      
        public string pod_type { get; set; } = string.Empty;    
        public string description { get; set; } = string.Empty;       
        public string image_path { get; set; } = string.Empty;
    }
}
