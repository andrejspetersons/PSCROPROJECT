using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_API.Context;
using Server_API.Models.Entity;
using Server_API.Models.WebFormsModels;

namespace Server_API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly PSICRODbContext _context;
        private readonly ValidationService _validationService;

        public UserService(PSICRODbContext context, ValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }

        public List<PaymentBillUserViewModel> GetClientPaymentBills(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join s in _context.CompanyServices on pb.Service.Id equals s.Id
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         where c.Login == username
                         select new PaymentBillUserViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = s.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = pb.PaymentDate,
                             PaymentReceipt = pb.PaymentReceipt,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();
            
            return query;
        }

        public bool isLoggedIn(string username)
        {
            var result = _context.Clients.FirstOrDefault(client => client.Login == username);
            return result != null;
        }

        public bool isRegistered(Client client)
        {
            if (_validationService.LoginExist(client.Login))
            {
                return false;
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            return true;
        }

        public bool PayTheBill(int billId)
        {
            var paymentBill = _context.PaymentBills.FirstOrDefault(bill => bill.Id == billId);

            if (paymentBill == null)
            {
                return false;
            }
            else
            {
                paymentBill.PaymentStatus = Status.PAID;
                paymentBill.PaymentDate = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
        }

        public bool UpdateReceipt(int billId, int receipt)
        {
            var paymentBill = _context.PaymentBills.FirstOrDefault(bill => bill.Id == billId);
            if (paymentBill == null)
            {
                return false;
            }
            else
            {
                paymentBill.PaymentReceipt = receipt;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
