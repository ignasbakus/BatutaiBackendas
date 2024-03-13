using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Image;
using api.Models;

namespace api.Mappers
{
    public static class ImageMappers
    {
        public static ImageDto toImageDto(this Image imageModel)
        {
            return new ImageDto
            {
                Id = imageModel.Id,
                ItemImage = imageModel.ItemImage,
                TrampolineId = imageModel.TrampolineId
            };
        }
    }
}