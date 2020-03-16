using System.ComponentModel.DataAnnotations;

namespace GigHub2.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}