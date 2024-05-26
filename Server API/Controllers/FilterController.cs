using Microsoft.AspNetCore.Mvc;
using Server_API.Services.FilterSwitcher;

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
                return Ok(result);
            }
            return NoContent();
        }

    }
}
