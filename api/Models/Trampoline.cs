using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    [Table("Trampolines")]
    public class Trampoline
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Length { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Image> Images { get; set; } = new List<Image>();
    }
}