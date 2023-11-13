using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
