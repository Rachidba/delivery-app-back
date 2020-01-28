namespace delivery_app_back.Models
{
    public class CourierItemDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Vehicle { get; set; }
    }
}