using AutoMapper;
using Gateways.Dto;
using Gateways.Models;

namespace Gateways.Profiles
{
    public class DevicesProfile : Profile
    {
        public DevicesProfile()
        {
            CreateMap<Device, DeviceReadDto>();
            CreateMap<DeviceCreateDto, Device>();
            CreateMap<Device, DeviceReadDto>()
              .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
              .ForMember(dest => dest.Vendor, opt => opt.MapFrom(src => src.Vendor))
              .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
