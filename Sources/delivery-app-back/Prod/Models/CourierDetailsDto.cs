namespace delivery_app_back.Models
{
    public class CourierDetailsDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Vehicle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}