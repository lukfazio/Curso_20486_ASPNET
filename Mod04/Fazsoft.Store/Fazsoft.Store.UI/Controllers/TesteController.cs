using Microsoft.AspNetCore.Mvc;

namespace Fazsoft.Store.UI.Controllers
{
    public class TesteController : Controller
    {
        public ContentResult Index() => Content("App OK!");
    }
}