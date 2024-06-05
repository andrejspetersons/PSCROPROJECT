using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server_API.Services.CompanyServices;
using System.Net;

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
            var resultUniq = _serviceValidator.Validate(serviceName, options => options.IncludeRuleSets("CheckDuplicates"));
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "Serivce is invalid.\nErrors:\n{errors}",
                    nameof(AddService),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));
                return BadRequest(result.Errors.Select(error => error.ErrorMessage));
            }
            else if (!resultUniq.IsValid) {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.Service with name {name} already exist", nameof(AddService), (int)HttpStatusCode.Conflict, serviceName);              
                return Conflict(resultUniq.Errors.Select(error=>error.ErrorMessage));
            }
            else
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(AddService), (int)HttpStatusCode.OK);
                var service = _companyServices.AddService(serviceName);
                return Ok(service);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateServiceById(int id, [FromBody]string serviceName)
        {
            var result = _serviceValidator.Validate(serviceName);
            var resultUniq = _serviceValidator.Validate(serviceName, options => options.IncludeRuleSets("CheckDuplicates"));
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "Serivce is invalid.\nErrors:\n{errors}",
                    nameof(UpdateServiceById),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));
                return BadRequest(result.Errors.Select(error => error.ErrorMessage));
            }
            else if (!resultUniq.IsValid)
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.Service with name {name} already exist", nameof(UpdateServiceById), (int)HttpStatusCode.Conflict, serviceName);
                return Conflict(resultUniq.Errors.Select(error => error.ErrorMessage));
            }
            else
            {
                var service = _companyServices.UpdateServiceById(id, serviceName);
                if (service == null)
                {
                    Log.Error("Method {method} was called with Result:{HttpStatusCode}.No service was found with id {id}", nameof(UpdateServiceById), (int)HttpStatusCode.NotFound, id);
                    return NotFound();
                }
                else
                {
                    Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(UpdateServiceById), (int)HttpStatusCode.OK);
                    return Ok(service);
                }
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteServiceById(int id)
        {
            if (_companyServices.DeleteServiceById(id))
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(DeleteServiceById), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.No service was found with id {id}", nameof(DeleteServiceById), (int)HttpStatusCode.NotFound, id);
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
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetServices), (int)HttpStatusCode.OK);
                return Ok(result);
            }
            else
            {
                Log.Warning("Method {method} was called with Result:{HttpStatusCode}.No services where found", nameof(GetServices), HttpStatusCode.NoContent);
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
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetServiceNames), (int)HttpStatusCode.OK);
                return Ok(result);
            }
            else
            {
                Log.Warning("Method {method} was called with Result:{HttpStatusCode}.No services where found", nameof(GetServiceNames), HttpStatusCode.NoContent);
                return NoContent();
            }
        }

    }
}
