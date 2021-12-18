using System.ComponentModel.DataAnnotations;

namespace Community.Models.Map
{
    public class Tree
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Area Area { get; set; }
    }
}