using AutoMapper;
using Gateways.Dto;
using Gateways.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Profiles
{
    public class GatewaysProfile : Profile
    {
        public GatewaysProfile()
        {
            CreateMap<Gateway, GatewayReadDto>();
            CreateMap<GatewayCreateDto, Gateway>();
            CreateMap<Gateway, GatewayReadDto>()
              .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
              .ForMember(dest => dest.IpAdress, opt => opt.MapFrom(src => src.IpAdress))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
