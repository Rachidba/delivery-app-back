using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery_app_back.Entities
{
    [Table("delivery_men")]
    public class DeliveryMan : User
    {
        [Column("vehicle")]
        public string Vehicle { get; set; }
    }
}