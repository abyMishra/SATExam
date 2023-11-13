using ContentService.DataAccess;
using ContentService.Models;
namespace ContentService.BusinessLogic
{
    public class ContentBusinessLogic : IContentBusinessLogic
    {
        private readonly CountryDataAccess _countryDataAccess;
        private readonly CurrenyDataAccess _currenyDataAccess;


        public ContentBusinessLogic(CountryDataAccess countryDataAccess, CurrenyDataAccess currenyDataAccess)
        {
            _countryDataAccess = countryDataAccess;
            _currenyDataAccess= currenyDataAccess;
        }
        public Task<List<Country>> GetCountryAsync()
        {
            return _countryDataAccess.GetAsync();
        }

        public Task<List<Currency>> GetCurrencyAsync()
        {
            return _currenyDataAccess.GetAsync();
        }

    }
}
