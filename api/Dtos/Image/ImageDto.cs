using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Image
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ItemImage { get; set; } = string.Empty;
        public int? TrampolineId { get; set; }
    }
}