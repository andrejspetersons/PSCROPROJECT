using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server_API.Models.WinFormsModels;
using Server_API.Services.AccountantService;
using Server_API.Services.UserService;
using System.Net;

namespace Server_API.Controllers
{
    [Route("payment-api")]
    public class PaymentBillController : Controller
    {
        private readonly IUserService _userservice;
        private readonly IAccountantService _accountantservice;
        private readonly IValidator<string>_receiptvalidator;
        private readonly IValidator<PaymentBillAccountantViewModel> _paymentbillvalidator;
        private readonly IMapper _mapper;

        public PaymentBillController(
            IUserService userservice,
            IAccountantService accountantservice,
            IValidator<string> receiptvalidator,
            IValidator<PaymentBillAccountantViewModel> paymentbillvalidator,
            IMapper mapper)
        {
            _userservice = userservice;
            _accountantservice = accountantservice;
            _receiptvalidator = receiptvalidator;
            _paymentbillvalidator = paymentbillvalidator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("paymentbill/{username}")]
        public IActionResult AddPaymentBill(string username,[FromBody] PaymentBillAccountantViewModel pbv)
        {
            var result = _paymentbillvalidator.Validate(pbv);
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "PaymentBill parameters is invalid.\nErrors:\n{errors}",
                    nameof(AddPaymentBill),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));

                return BadRequest(result.Errors.Select(error => error.ErrorMessage));
            }
            else
            {
                var paymentBill = _accountantservice.AddPaymentBill(username, pbv);
                if(paymentBill==null)
                {
                    Log.Warning("Method {method} was called with Result:{HttpStatusCode}.PaymentBill parameters not found", nameof(AddPaymentBill), HttpStatusCode.NoContent);
                    return NotFound();
                }
                else
                {
                    Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(AddPaymentBill), (int)HttpStatusCode.OK);
                    return Ok(_mapper.Map<PaymentBillAccountantViewModel>(paymentBill));    
                }
                 
            }
                        
        }

        [HttpGet]
        [Route("paymentbill/{username}")]
        public IActionResult GetPaymentBillsByClientLogin(string username)
        {
            var clientPaymentBills = _accountantservice.GetPaymentBillsByClientLogin(username);

            if (clientPaymentBills.Count > 0)
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetPaymentBillsByClientLogin), (int)HttpStatusCode.OK);
                return Ok(clientPaymentBills);
            }

            Log.Warning("Method {method} was called with Result:{HttpStatusCode}.There is no bills for {Username}", nameof(GetPaymentBillsByClientLogin), HttpStatusCode.NoContent, username);
            return NoContent();

        }

        [HttpPut]
        [Route("paymentbill/{id}")]
        public IActionResult UpdatePaymentBillById(int id, [FromBody] PaymentBillAccountantViewModel pbv)
        {
            var result = _paymentbillvalidator.Validate(pbv);
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "PaymentBill parameters is invalid.\nErrors:\n{errors}",
                    nameof(UpdatePaymentBillById),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));

                return BadRequest(result.Errors.Select(error => error.ErrorMessage));
            }
            else
            {
                var updatedPaymentBill = _accountantservice.UpdatePaymentBillById(id, pbv);
                if (updatedPaymentBill==null)
                {
                    Log.Error("Method {method} was called with Result:{HttpStatusCode}.No bill was found with id {id}", nameof(UpdatePaymentBillById), (int)HttpStatusCode.NotFound, id);
                    return NotFound();
                }
                else
                {
                    Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(UpdatePaymentBillById), (int)HttpStatusCode.OK);
                    return Ok(_mapper.Map<PaymentBillAccountantViewModel>(updatedPaymentBill));
                }
            }
        }

        [HttpPut]
        [Route("updatereceipt/{id}")]
        public IActionResult UpdateReceipt(int id,[FromBody]string receipt)
        {
            var result = _receiptvalidator.Validate(receipt);
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "Receipt is invalid.\nErrors:\n{errors}",
                    nameof(UpdateReceipt),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));

                return BadRequest(result.Errors.Select(error => error.ErrorMessage));    
            }

            if (_userservice.UpdateReceipt(id,receipt))
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(UpdateReceipt), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.No receipt was found with id {id}", nameof(UpdateReceipt), (int)HttpStatusCode.NotFound, id);
                return NotFound();
            }
            
        }

        [HttpDelete]
        [Route("paymentbill/{id}")]
        public IActionResult DeletePaymentBillById(int id)
        {
            if (_accountantservice.DeletePaymnentBillById(id))
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(DeletePaymentBillById), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.No bill was found with id {id}", nameof(DeletePaymentBillById), (int)HttpStatusCode.NotFound, id);
                return NotFound();
            }
        }
    }
}
