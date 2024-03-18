using System.ComponentModel.DataAnnotations;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class WoodComponent
    {
        public int Id { get; set; }

        [Required]
        public int WoodId { get; set; }

        [Required]
        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; } = new();

        public virtual Wood Wood { get; set; } = new();
    }
}