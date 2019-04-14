using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Helpers;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public IActionResult SignIn(SignInVM model)
        {
            var usuario = _usuarioRepository.GetByEmail(model.Email);


            if (usuario == null)
            {
                ModelState.AddModelError("Email", "Email não cadastrado!");
            }
            else
            {
                if (model.Senha.Encrypt() != usuario.Senha)
                    ModelState.AddModelError("Senha", "Senha Inválida!");
            }

            if (ModelState.IsValid)
            {
                //Gerar o cookie
                var claims = new List<Claim>()
                {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("nome", usuario.Nome),
                    new Claim("email", usuario.Email),
                    new Claim("perfils", string.Join(',', (new string[]{ "admin", "ti" })))
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "email", "perfils");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);

                return RedirectToAction("Index", "Produtos");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
