namespace Restful_API.Model
{
    public class User
    {
        public int id { get; set; }
        public string fname { get; set; } = string.Empty;
        public string mname { get; set; } = string.Empty;
        public string lname { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string contact_num { get; set; } = string.Empty;
        public string email_add { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;      
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public User()
        {
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }
    }
}
