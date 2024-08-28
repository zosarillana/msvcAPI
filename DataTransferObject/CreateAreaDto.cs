using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class CreateAreaDto
    {
        public int id { get; set; }
        public string area { get; set; } = string.Empty;      
        public string description { get; set; } = string.Empty;
    }
}
