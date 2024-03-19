using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Trampoline
{
    public class CreateTrampolineRequestDto
    {
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [MaxLength(20, ErrorMessage = "Per ilgas pavadinimas")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [Range(1, 500)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [Range(0.5, 50)]
        public decimal Width { get; set; }
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [Range(0.5, 50)]
        public decimal Length { get; set; }
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [Range(0.5, 50)]
        public decimal Height { get; set; }
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [MaxLength(400, ErrorMessage = "Per ilgas aprašymas")]
        public string Description { get; set; } = string.Empty;
    }
}