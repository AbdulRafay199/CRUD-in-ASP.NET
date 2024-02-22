using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testApp.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public int orderAmount { get; set; }

        public DateTime orderedAt { get; set; } = DateTime.Now;

    }
}
