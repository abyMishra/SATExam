using ContentService.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using ContentService.Models;

namespace ContentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : Controller
    {
        private readonly IContentBusinessLogic _contentBusinessLogic;
        public ContentController(IContentBusinessLogic contentBusinessLogic)
        {
            _contentBusinessLogic = contentBusinessLogic;
        }


        // GET: api/<UsersController>
        [HttpGet("allCountry")]
        public async Task<List<Country>> GetAllCountry()
        {
            return await _contentBusinessLogic.GetCountryAsync();
        }


        // GET: api/<UsersController>
        [HttpGet("allCurrency")]
        public async Task<List<Currency>> GetAllCurrency()
        {
            return await _contentBusinessLogic.GetCurrencyAsync();
        }

    }
}
