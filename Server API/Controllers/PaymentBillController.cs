using Microsoft.AspNetCore.Mvc;
using Server_API.Context;
using Server_API.Models.Entity;
using WebFormsModel = Server_API.Models.WebFormsModels;
using WinFormsModel = Server_API.Models.WinFormsModels;

namespace Server_API.Controllers
{
    public class PaymentBillController : Controller
    {
        private PSICRODbContext _context;
        public PaymentBillController(PSICRODbContext context)
        {
            _context = context;    
        }

        [HttpPost]
        [Route("paymentbill")]
        public IActionResult AddPaymentBill([FromBody]WinFormsModel.PaymentBillViewModel pbv)
        {
            PaymentBill paymentBill = new PaymentBill()
            {
                Client = _context.Clients.FirstOrDefault(client => client.Login == pbv.Login)!,
                Service = _context.CompanyServices.FirstOrDefault(service => service.Name == pbv.ServiceName)!,
                Amount = pbv.Amount,
                IssueDate = pbv.IssueDate,
                DueToDate = pbv.DueToDate,             
            };

            _context.PaymentBills.Add(paymentBill);
            _context.SaveChanges();
            return Ok(paymentBill);

        }

        [HttpPut]
        [Route("paymentbill/{id}")]
        public async Task<IActionResult> PayTheBill(int id, [FromBody]int receipt)
        {
            var paymentBill = _context.PaymentBills.FirstOrDefault(bill => bill.Id == id);

            if (paymentBill == null)
            {
                NotFound();
            }
                paymentBill.PaymentReceipt = receipt;
                paymentBill.PaymentStatus = Status.PAID;
                paymentBill.PaymentDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(paymentBill);
        }

    }
}
