using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_API.Context;
using Server_API.Models.Entity;
using Server_API.Models.WebFormsModels;

namespace Server_API.Controllers
{
    public class ClientController : Controller
    {
        private readonly PSICRODbContext _context;
        private readonly IMapper _mapper;
        
        public ClientController(PSICRODbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("payment/{username}")]
        public IActionResult GetClientPaymentBills(string username)
        {
            var client = _context.Clients.FirstOrDefault(client => client.Login == username);
            var service = _context.CompanyServices.Where(service => service.Id == 1).FirstOrDefault();
            if (client != null)
            {
                var id = client.Id;
                var clientBills = _context.PaymentBills
                    .Where(bill => bill.Client.Id == id && bill.Service.Id == 1)
                    .Where(service => service.Service.Id == 1).ToList();

                
                return Ok(MapToPVMList(clientBills));


            }
            return NotFound();
        }

        public IEnumerable<PaymentBillViewModel> MapToPVMList(IEnumerable<PaymentBill> paymentBills)
        {
            return paymentBills.Select(paymentBill => _mapper.Map<PaymentBillViewModel>(paymentBill));
        }
    }
}
