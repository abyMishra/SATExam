namespace IdentityService.BusinessLogic;

public interface IIdentityBusinessLogic
{
    Models.SecurityToken Authenticate(string username, string password);

    string Decryptforge(string password, int CompanyID);

    string GetCompanyPublicDetails(string Username, string CompanyN);
}
