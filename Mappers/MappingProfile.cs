using AutoMapper;
using delivery_app_back.Entities;
using delivery_app_back.Models;

namespace delivery_app_back.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Courier, CourierItemDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    src => $"{src.FirstName} {src.LastName}"));
            
            CreateMap<Courier, CourierDetailsDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CourierForCreationDto, Courier>();
        }
    }
}