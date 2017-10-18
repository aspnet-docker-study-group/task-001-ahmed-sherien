using Microsoft.AspNetCore.Mvc;

namespace Students.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}