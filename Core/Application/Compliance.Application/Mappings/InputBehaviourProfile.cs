using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours;
using Compliance.Domain.Models;


namespace Compliance.Application.Mappings
{
    /// <summary>
    /// Input Behaviour Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class InputBehaviourProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputBehaviourProfile"/> class.
        /// </summary>
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
