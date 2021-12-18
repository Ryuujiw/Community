using System.ComponentModel.DataAnnotations;

namespace Community.Models.Map
{
    public class Area
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Tree> Trees { get; set; }
        public float Size { get; set; }
    }
}
