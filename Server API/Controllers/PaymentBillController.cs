using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Server_API.Models.WinFormsModels;
using Server_API.Services.AccountantService;
using Server_API.Services.UserService;

namespace Server_API.Controllers
{
    public class PaymentBillController : Controller
    {
        private readonly IUserService _userservice;
        private readonly IAccountantService _accountantservice;
        private readonly IValidator<int>_receiptvalidator;
        private readonly IValidator<PaymentBillAccountantViewModel> _paymentbillvalidator;

        public PaymentBillController(
            IUserService userservice,
            IAccountantService accountantservice,
            IValidator<int> receiptvalidator,
            IValidator<PaymentBillAccountantViewModel> paymentbillvalidator)
        {
            _userservice = userservice;
            _accountantservice = accountantservice;
            _receiptvalidator = receiptvalidator;
            _paymentbillvalidator = paymentbillvalidator;
        }

        [HttpPost]
        [Route("paymentbill/{username}")]
        public IActionResult AddPaymentBill(string username,PaymentBillAccountantViewModel pbv)
        {
            var result = _paymentbillvalidator.Validate(pbv);
            if (!result.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _accountantservice.AddPaymentBill(username, pbv);
                return Ok(); 
            }
                        
        }

        [HttpGet]
        [Route("paymentbill/{username}")]
        public IActionResult GetPaymentBillsByClientLogin(string username)
        {
            var clientPaymentBills = _accountantservice.GetPaymentBillsByClientLogin(username);

            if (clientPaymentBills.Count > 0)
            {
                return Ok(clientPaymentBills);
            }

            return NoContent();

        }

        [HttpPut]
        [Route("paymentbill/{id}")]
        public IActionResult UpdatePaymentBillById(int id, [FromBody] PaymentBillAccountantViewModel pbv)
        {
            var result = _paymentbillvalidator.Validate(pbv);
            if (!result.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (_accountantservice.UpdatePaymentBillById(id, pbv))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPut]
        [Route("updatereceipt/{id}")]
        public IActionResult UpdateReceipt(int id,[FromBody]int receipt)
        {
            var result = _receiptvalidator.Validate(receipt);
            if (!result.IsValid)
            {
                return BadRequest(receipt);    
            }

            if (_userservice.UpdateReceipt(id,receipt))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpDelete]
        [Route("paymentbill/{id}")]
        public IActionResult DeletePaymentBillById(int id)
        {
            if (_accountantservice.DeletePaymnentBillById(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
