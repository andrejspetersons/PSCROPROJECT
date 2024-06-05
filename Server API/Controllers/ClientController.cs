using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server_API.Models.Entity;
using Server_API.Models.WinFormsModels;
using Server_API.Services.AccountantService;
using Server_API.Services.ClientService;
using Server_API.Services.UserService;
using System.Net;

namespace Server_API.Controllers
{
    [Route("client-api")]
    public class ClientController : Controller
    {
        private readonly IUserService _userservice;
        private readonly IAccountantService _accountantservice;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IValidator<Client> _clientValidator;

        public ClientController(IUserService userservice, IAccountantService accountantservice, IClientService clientService, IMapper mapper, IValidator<Client> clientValidator)
        {
            _userservice = userservice;
            _accountantservice = accountantservice;
            _clientService = clientService;
            _mapper = mapper;
            _clientValidator = clientValidator;
        }

        [HttpGet]
        [Route("paymentbills/{username}")]
        public IActionResult GetClientPaymentBills(string username)
        {
            var clientBills = _userservice.GetClientPaymentBills(username);
            if (clientBills.Count>0)
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetClientPaymentBills), (int)HttpStatusCode.OK);
                return Ok(clientBills);
            }

            Log.Warning("Method {method} was called with Result:{HttpStatusCode}.There is no bills for {Username}", nameof(GetClientPaymentBills), HttpStatusCode.NoContent, username);
            return NoContent();        
        }

        [HttpPut]
        [Route("paybill/{id}")]
        public IActionResult PayTheBill(int id)
        {
            if (_userservice.PayTheBill(id))
            {
                Log.Information("Method {method} was called .Result:{HttpStatusCode}", nameof(PayTheBill), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.Bill Id {id} not found", nameof(PayTheBill), id, (int)HttpStatusCode.NotFound);
                return NotFound();
            }
        }

        [HttpGet]
        [Route("clientslogins")]
        public IActionResult GetAllClientsUsernames()
        {
            var result = _accountantservice.GetAllClientsUserNames();
            if (result.Count > 0)
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetAllClientsUsernames), (int)HttpStatusCode.OK);
                return Ok(result);
            }
            else
            {
                Log.Warning("Method {method} was called with Result:{HttpStatusCode}.No usernames were found", nameof(GetAllClientsUsernames), (int)HttpStatusCode.NoContent);
                return NoContent();
            }
            
            
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddClient([FromBody] Client client)
        {
            var result = _clientValidator.Validate(client);
            var resultUniq = _clientValidator.Validate(client, options => options.IncludeRuleSets("CheckDuplicates"));
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "Client parameters is invalid.\nErrors:\n{errors}", 
                    nameof(AddClient), 
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n",result.Errors.Select(error => error.ErrorMessage)));

                return BadRequest(result.Errors.Select(error=>error.ErrorMessage));
            }
            else if(!resultUniq.IsValid)
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.Client parameters are not uniq.\nDuplicates:\n{duplicates}", 
                    nameof(AddClient), 
                    (int)HttpStatusCode.Conflict,
                    string.Join("\n", resultUniq.Errors.Select(error => error.ErrorMessage)));
                return Conflict(resultUniq.Errors.Select(error=>error.ErrorMessage));
            }
            else
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}",nameof(AddClient),(int)HttpStatusCode.OK);
                var newClient=_clientService.AddClient(client);
                return Ok(_mapper.Map<ClientAccountantViewModel>(client));
            }
            
        }

        [HttpGet]
        [Route("clients")]
        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClients();
            if (result.Count > 0)
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(GetAllClients), (int)HttpStatusCode.OK);
                return Ok(_mapper.Map<List<ClientAccountantViewModel>>(result));
            }
            else
            {
                Log.Warning("Method {method} was called with Result:{HttpStatusCode}.No clients were found", nameof(GetAllClients), (int)HttpStatusCode.NoContent);
                return NoContent();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateClientById(int id, [FromBody] Client updatedClient)
        {
            var result = _clientValidator.Validate(updatedClient);
            if (!result.IsValid)
            {
                Log.Error("Method {method} was called with" +
                    "Result:{HttpStatusCode}." +
                    "Client parameters is invalid.\nErrors:\n{errors}",
                    nameof(UpdateClientById),
                    (int)HttpStatusCode.BadRequest,
                    string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));

                return BadRequest(result.Errors.Select(error=>error.ErrorMessage));
            }
            else
            {
                var client = _clientService.UpdateClientById(id, updatedClient);
                if (client == null)
                {
                    Log.Error("Method {method} was called with Result:{HttpStatusCode}.No client was found with id {id}", nameof(UpdateClientById), (int)HttpStatusCode.NotFound, id);
                    return NotFound();
                }
                else
                {
                    Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(UpdateClientById), (int)HttpStatusCode.OK);
                    return Ok(_mapper.Map<ClientAccountantViewModel>(client));    
                }
            }  
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteClientById(int id)
        {
            if (_clientService.DeleteClientById(id))
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(DeleteClientById), (int)HttpStatusCode.OK);
                return Ok();
            }
            else
            {
                Log.Error("Method {method} was called with Result:{HttpStatusCode}.No client was found with id {id}", nameof(DeleteClientById), (int)HttpStatusCode.NotFound, id);
                return NotFound();
            }
        }
    }
}
