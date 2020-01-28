using System.ComponentModel.DataAnnotations.Schema;

namespace delivery_app_back.Entities
{
    [Table("sellers")]
    public class Seller : User
    {
        [Column("category")]
        public string Category { get; set; }
    }
}