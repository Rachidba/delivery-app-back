using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery_app_back.Entities
{
    [Table("courier")]
    public class Courier : User
    {
        [Column("vehicle")]
        public string Vehicle { get; set; }
    }
}