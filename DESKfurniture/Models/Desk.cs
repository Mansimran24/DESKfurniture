using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DESKfurniture.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string Shop { get; set; }
        public string Usage { get; set; }

        public string Material { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
