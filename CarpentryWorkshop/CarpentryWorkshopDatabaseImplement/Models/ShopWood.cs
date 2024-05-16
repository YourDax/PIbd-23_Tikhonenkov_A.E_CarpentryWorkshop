using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class ShopWood
    {
        public int Id { get; set; }

        [Required]
        public int WoodId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Shop Shop { get; set; } = new();

        public virtual Wood Wood { get; set; } = new();
    }
}
