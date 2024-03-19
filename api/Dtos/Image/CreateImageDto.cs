using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Image
{
    public class CreateImageDto
    {
        [Required(ErrorMessage = "Laukas negali būti tuščias")]
        [MinLength(5, ErrorMessage = "Nuotraukos URL per trumpas")]
        public string ItemImage { get; set; } = string.Empty;
    }
}