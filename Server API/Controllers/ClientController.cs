using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Server_API.Models.Entity;
using Server_API.Models.WinFormsModels;
using Server_API.Services;
using Server_API.Services.AccountantService;
using Server_API.Services.ClientService;
using Server_API.Services.UserService;

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
        private readonly ValidationService _validationService;

        public ClientController(IUserService userservice, IAccountantService accountantservice, IClientService clientService, IMapper mapper, IValidator<Client> clientValidator, ValidationService validationService)
        {
            _userservice = userservice;
            _accountantservice = accountantservice;
            _clientService = clientService;
            _mapper = mapper;
            _clientValidator = clientValidator;
            _validationService = validationService;
        }

        [HttpGet]
        [Route("paymentbills/{username}")]
        public IActionResult GetClientPaymentBills(string username)
        {
            var clientBills = _userservice.GetClientPaymentBills(username);
            if (clientBills.Count>0)
            {              
                return Ok(clientBills);
            }

            return NoContent();        
        }

        [HttpPut]
        [Route("paybill/{id}")]
        public IActionResult PayTheBill(int id)
        {
            if (_userservice.PayTheBill(id))
            {
                return Ok();
            }
            else
            {
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
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
            
            
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddClient([FromBody] Client client)
        {
            var result = _clientValidator.Validate(client);
            if (!result.IsValid)
            {
                return BadRequest(client);
            }
            else if(_validationService.LoginExist(client.Login))
            {
                return Conflict();
            }
            else
            {
                _clientService.AddClient(client);
                return Ok(client);
            }
            
        }

        [HttpGet]
        [Route("clients")]
        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClients();
            if (result.Count > 0)
            {
                return Ok(_mapper.Map<List<ClientAccountantViewModel>>(result));
            }
            else
            {
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
                return BadRequest(updatedClient);
            }
            
            if (_clientService.UpdateClientById(id,updatedClient))
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
        public IActionResult DeleteClientById(int id)
        {
            if (_clientService.DeleteClientById(id))
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
