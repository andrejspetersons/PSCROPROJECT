using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Server_API.Services.CompanyServices;

namespace Server_API.Controllers
{
    [Route("service-api")]
    public class CompanyServiceController : Controller
    {
        private readonly ICompanyServices _companyServices;
        private readonly IValidator<string> _serviceValidator;
        public CompanyServiceController(ICompanyServices companyServices, IValidator<string> serviceValidator)
        {
            _companyServices = companyServices;
            _serviceValidator = serviceValidator;
        }

        [HttpPost]
        [Route("add")]      
        public IActionResult AddService([FromBody]string serviceName)
        {
            var result = _serviceValidator.Validate(serviceName);
            if (!result.IsValid)
            {
                return BadRequest(serviceName);
            }

            if (_companyServices.AddService(serviceName))
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateServiceById(int id, [FromBody]string serviceName)
        {
            var result = _serviceValidator.Validate(serviceName);
            if (!result.IsValid)
            {
                return BadRequest(serviceName);
            }
            if (_companyServices.UpdateServiceById(id,serviceName))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteServiceById(int id)
        {
            if (_companyServices.DeleteServiceById(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("services")]
        public IActionResult GetServices()
        {
            var result = _companyServices.GetAllServices();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("servicenames")]
        public IActionResult GetServiceNames()
        {
            var result = _companyServices.GetServiceNames();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
