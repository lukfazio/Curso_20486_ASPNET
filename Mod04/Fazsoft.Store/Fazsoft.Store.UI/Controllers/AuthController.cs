using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fazsoft.Store.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AuthController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Login(string returnURL, AuthVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _usuarioRepository.SignInAsync(model.Email, model.Senha);

            if (user == null)
            {
                ModelState.AddModelError("", "Email ou Senha inválidos!");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim("nomeUsuario", user.Nome),
                new Claim("email", user.Email),
                new Claim("idUsuario", user.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims
                                    , CookieAuthenticationDefaults.AuthenticationScheme
                                    , "nomeUsuario"
                                    , string.Join(", ", user.Perfis?.Select(x => x.Nome)));

            await HttpContext.SignInAsync(new ClaimsPrincipal(identity)
                                          , new AuthenticationProperties
                                          {
                                              ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                                          });

            if (string.IsNullOrEmpty(returnURL) && Url.IsLocalUrl(returnURL))
            {
                return Redirect(returnURL);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
