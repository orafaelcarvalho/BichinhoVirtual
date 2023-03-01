using AutoMapper;

namespace BichinhoVirtual.Model
{
    public class MascoteMapping
    {
        public MascoteMapping()
        {
            Mapper.CreateMap<Pokemon, Mascote>()
                .ForMember(dest => dest.height, opt => opt.MapFrom(src => src.height))
                .ForMember(dest => dest.weight, opt => opt.MapFrom(src => src.weight))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.abilities, opt => opt.MapFrom(src => src.abilities));
        }
    }
}