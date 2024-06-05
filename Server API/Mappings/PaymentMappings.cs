using AutoMapper;
using Server_API.Models.Entity;
using Server_API.Models.WinFormsModels;

namespace Server_API.Mappings
{
    public class PaymentMappings:Profile
    {
        public PaymentMappings()
        {
            CreateMap<PaymentBill, PaymentBillAccountantViewModel>()
                .ForMember(dest => dest.PaymentBillId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.DueToDate, opt => opt.MapFrom(src => src.DueToDate))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => Enum.GetName(src.PaymentStatus)));

        }
    }
}
