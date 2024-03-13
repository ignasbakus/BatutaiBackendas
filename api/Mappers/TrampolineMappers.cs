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
                Price = trampolineModel.Price,
                Width = trampolineModel.Width,
                Length = trampolineModel.Length,
                Height = trampolineModel.Height,
                Description = trampolineModel.Description
            };
        }

        public static Trampoline ToTrampolineFromCreateDTO(this CreateTrampolineRequestDto trampolineDto)
        {
            return new Trampoline
            {
                Name = trampolineDto.Name,
                Price = trampolineDto.Price,
                Width = trampolineDto.Width,
                Length = trampolineDto.Length,
                Height = trampolineDto.Height,
                Description = trampolineDto.Description
            };
        }
    }
}