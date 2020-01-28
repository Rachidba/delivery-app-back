using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery_app_back.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        
        [Column("city")]
        public string City { get; set; }
        
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
    }
}