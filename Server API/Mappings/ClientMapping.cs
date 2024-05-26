using AutoMapper;
using Server_API.Models.Entity;
using Server_API.Models.WinFormsModels;

namespace Server_API.Mappings
{
    public class ClientMapping:Profile
    {
        public ClientMapping()
        {
            CreateMap<Client, ClientAccountantViewModel>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
