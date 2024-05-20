using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int? Stock { get; set; }


    }
}
