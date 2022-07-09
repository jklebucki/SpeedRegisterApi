using AutoMapper;
using SpeedRegisterApi.DTO;
using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Settings
{
    public class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<Tabor, TaborDto>()
                .ForMember(
                    dest => dest.IdTaboru,
                    opt => opt.MapFrom(src => src.IdTaboru)
                )
                .ForMember(
                    dest => dest.Marka,
                    opt => opt.MapFrom(src => src.Marka)
                )
                .ForMember(
                    dest => dest.NrRej,
                    opt => opt.MapFrom(src => src.NrRej)
                )
                .ForMember(
                    dest => dest.Podwykonawca,
                    opt => opt.MapFrom(src => src.Podwykonawca)
                )
                .ForMember(
                    dest => dest.Dzial,
                    opt => opt.MapFrom(src => src.Dzial)
                )
                .ForMember(
                    dest => dest.Wlasciciel,
                    opt => opt.MapFrom(src => src.Wlasciciel)
                );
        }
    }
}
