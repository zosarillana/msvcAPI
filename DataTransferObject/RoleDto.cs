using System.ComponentModel.DataAnnotations;

namespace Restful_API.DataTransferObject
{
    public class RoleDto
    {
        public int id { get; set; }     
        public int role_id { get; set; }
        public string role_description { get; set; } = string.Empty;
    }
}
