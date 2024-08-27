namespace Restful_API.DataTransferObject
{
    public class UpdateRoleDto
    {
        public int id { get; set; }
        public string role { get; set; } = string.Empty;
        public string role_description { get; set; } = string.Empty;
    }
}
