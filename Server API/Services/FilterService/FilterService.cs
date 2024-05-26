using Server_API.Context;
using Server_API.Models.WinFormsModels;

namespace Server_API.Services.FilterService
{
    public class FilterService : IFilterService
    {
        private readonly PSICRODbContext _context;
        public FilterService(PSICRODbContext context)
        {
            _context = context;
        }

        public List<PaymentBillAccountantViewModel> OrderByPaymentBillId(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.Id
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByAmount(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.Amount
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByDueToDate(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.DueToDate
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)

                         }).ToList();
            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByIssueDate(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.IssueDate
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByPaymentDate(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.PaymentDate descending
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByPaymentStatus(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.PaymentStatus
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }

        public List<PaymentBillAccountantViewModel> OrderByServiceName(string username)
        {
            var query = (from pb in _context.PaymentBills
                         join c in _context.Clients on pb.Client.Id equals c.Id
                         join cs in _context.CompanyServices on pb.Service.Id equals cs.Id
                         where c.Login == username
                         orderby pb.Service.Name
                         select new PaymentBillAccountantViewModel
                         {
                             PaymentBillId = pb.Id,
                             ServiceName = cs.Name,
                             Amount = pb.Amount,
                             IssueDate = pb.IssueDate,
                             DueToDate = pb.DueToDate,
                             PaymentDate = (DateTime?)pb.PaymentDate,
                             PaymentStatus = Enum.GetName(pb.PaymentStatus)
                         }).ToList();

            return query;
        }
    }
}
