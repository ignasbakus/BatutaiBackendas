using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trampoline;
using api.Models;

namespace api.Mappers
{
    public static class TrampolineMappers
    {
        public static TrampolineDto ToTrampolineDto(this Trampoline trampolineModel)
        {
            return new TrampolineDto
            {
                Id = trampolineModel.Id,
                Name = trampolineModel.Name,
                Image = trampolineModel.Image,
                Price = trampolineModel.Price,
                Width = trampolineModel.Width,
                Length = trampolineModel.Length,
                Height = trampolineModel.Height,
                Description = trampolineModel.Description
            };
        }
    }
}