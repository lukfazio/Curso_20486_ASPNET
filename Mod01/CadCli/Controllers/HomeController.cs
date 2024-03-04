using Microsoft.AspNetCore.Mvc;

namespace CadCli.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        //home/about       
        public ViewResult About()
        {
            return View();
        }
    }
}