using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server_API.Services.FilterSwitcher;
using System.Net;

namespace Server_API.Controllers
{
    public class FilterController : Controller
    {
        private readonly IFilterSwitcher _filterSwitcher;
        public FilterController(IFilterSwitcher filterSwitcher)
        {
            _filterSwitcher = filterSwitcher;
        }
        [HttpPost]
        [Route("orderby/{columnName}")]
        public IActionResult OrderByColumn(string columnName, [FromBody]string username)
        {
            var result = _filterSwitcher.SwitchColumnParameter(columnName, username);
            if (result.Count > 0)
            {
                Log.Information("Method {method} was called with Result:{HttpStatusCode}", nameof(OrderByColumn), (int)HttpStatusCode.OK);
                return Ok(result);
            }

            Log.Information("Method {method} was called with Result:{HttpStatusCode}.No columns was found for username {username}.", nameof(OrderByColumn), (int)HttpStatusCode.NoContent, username);
            return NoContent();
        }

    }
}
