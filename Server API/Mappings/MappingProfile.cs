using AutoMapper;
using Server_API.Models.Entity;
using Server_API.Models.WebFormsModels;

namespace Server_API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentBill, PaymentBillViewModel>()
                .ForMember(destBill => destBill.ServiceName,
                option => option.MapFrom(sourceBill => sourceBill.Service.Name))

                .ForMember(destBill => destBill.Amount,
                option => option.MapFrom(sourceBill => sourceBill.Amount))

                .ForMember(destBill => destBill.IssueDate,
                option => option.MapFrom(sourceBill => sourceBill.IssueDate))

                .ForMember(destBill => destBill.DueToDate,
                option => option.MapFrom(sourceBill => sourceBill.DueToDate))

                .ForMember(destBill => destBill.PaymentDate,
                option => option.MapFrom(sourceBill => sourceBill.PaymentDate))

                .ForMember(destBill=>destBill.PaymentReceipt,
                option=>option.MapFrom(sourceBill=>sourceBill.PaymentReceipt))

                .ForMember(destBill => destBill.PaymentStatus,
                option => option.MapFrom(sourceBill =>Enum.GetName(typeof(Status),sourceBill.PaymentStatus)));


        }
    }
}
