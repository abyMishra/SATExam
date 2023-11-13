using IdentityService.Models;
using IdentityService.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/Identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IIdentityBusinessLogic _identityBusinessLogic;

        public IdentityController(IIdentityBusinessLogic identityBusinessLogic)
        {
            _identityBusinessLogic = identityBusinessLogic;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            //Angular Password to be decrypted From UI
            var decrptPassword = _identityBusinessLogic.Decryptforge(loginParam.Password, 1);

            var token = _identityBusinessLogic.Authenticate(loginParam.Username, decrptPassword);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("PublicDetails")]
        public IActionResult GetCompanyPublicDetails([FromBody] Login loginParam)
        {
            //Angular Password to be decrypted From UI

            string CompanyN = "";
            var token = _identityBusinessLogic.GetCompanyPublicDetails(loginParam.Username, CompanyN);

            if (token == null)
                return BadRequest(new { message = "Username/URL  incorrect" });

            return Ok(token);
        }
    }
}
