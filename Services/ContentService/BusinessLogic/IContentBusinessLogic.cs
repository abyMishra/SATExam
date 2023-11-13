
using ContentService.Models;
namespace ContentService.BusinessLogic
{
    public interface IContentBusinessLogic
    {
        public Task<List<Country>> GetCountryAsync();

        public Task<List<Currency>> GetCurrencyAsync();
    }
}
