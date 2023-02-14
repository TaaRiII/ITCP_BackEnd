using AutoMapper;
using ITCPBackend.DTOs;
using ITCPBackend.Model;
using Newtonsoft.Json;

namespace ITCPBackend.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectDurationModel, ProjectDuration>().ReverseMap();
            CreateMap<Notification, NotificationDto>().ReverseMap();
            //CreateMap<ProjectCostDto, ProjectCost>().ForMember(dest => dest.CostDetails,opt=> opt.MapFrom(src=>JsonConvert.SerializeObject(src.CostDetails))).ReverseMap();
        }
    }
}
