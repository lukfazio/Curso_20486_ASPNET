using Microsoft.AspNetCore.Mvc;

namespace Fazsoft.Store.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About() => View();
    }
}