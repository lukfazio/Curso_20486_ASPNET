using Microsoft.AspNetCore.Mvc;

namespace CadCli
{
    //http://localhost:5000/Teste/Ping
    //public class TesteController
    //[Controller]
    public class Teste : Controller
    {
        public string Ping()
        {
            return "Pong!";
        }

    }
}
