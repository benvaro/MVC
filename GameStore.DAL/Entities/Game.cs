using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int? Year { get; set; }
        [Required]
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public Developer Developer { get; set; }
    }
}
