namespace Restful_API.DataTransferObject
{
    public class UpdateAreaDto
    {
        public int id { get; set; }
        public string area { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
