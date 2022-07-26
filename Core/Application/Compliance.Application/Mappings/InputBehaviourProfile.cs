using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours;
using Compliance.Domain.Models;


namespace Compliance.Application.Mappings
{
    public class InputBehaviourProfile : Profile
    {
        public InputBehaviourProfile()
        {
            CreateMap<CreateInputBehavioursCommand, InputBehaviour>();

            CreateMap<InputBehaviour, InputBehaviourCreateResponse>()
             .ForMember(dest => dest.InputBehaviourId, opt => opt.MapFrom(src => src.InputBehaviourId));

            CreateMap<InputBehaviour, InputBehaviourResponse>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

        }
    }
}
