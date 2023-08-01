using AutoMapper;
using GrpcService;
using POSMS.Dtos;
using POSMS.Models;

namespace POSMS.Profiles
{
    public class ApplicationProfiles : Profile
    {
        public ApplicationProfiles()
        {
            CreateMap<Device, DeviceDto>().ReverseMap()
              .ForAllMembers(opts =>
              opts.Condition((src, dest, srcMember) => srcMember != null)
              );
            CreateMap<Device, CreateDeviceDto>().ReverseMap()
              .ForAllMembers(opts =>
              opts.Condition((src, dest, srcMember) => srcMember != null)
              );
            CreateMap<Device, UpdateDeviceDto>().ReverseMap()
              .ForAllMembers(opts =>
              opts.Condition((src, dest, srcMember) => srcMember != null)
              );
            CreateMap<Device, DeviceRepairDTO>().ReverseMap()
              .ForAllMembers(opts =>
              opts.Condition((src, dest, srcMember) => srcMember != null)
              );
            CreateMap<Device, GrpcDevice>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
               .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
               .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
               .ForMember(dest => dest.IMEI, opt => opt.MapFrom(src => src.IMEI))
               .ForMember(dest => dest.SendToRepair, opt => opt.MapFrom(src => src.SendToRepair));
        }
    }
}
