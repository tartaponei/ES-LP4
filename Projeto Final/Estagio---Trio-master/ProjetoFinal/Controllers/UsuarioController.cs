using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);

                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(UsuarioModel usuario)
        {
            bool login = usuario.Autenticar();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("UsuarioLogado", "Usuario");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Usuario ou senha inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult CadastroUsuario()
        {
            return View();

        }
        public IActionResult UsuarioLogado()
        {
            return View();

        }

        public IActionResult PagUsuario()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
           
            bool cadastro = usuario.Cadastrar();

            if (cadastro)
            {
                TempData["MensagemCadastroSucesso"] = "Usuario cadastrado com sucesso!";
                return RedirectToAction("CadastroUsuario");
            }
            else
            {
                TempData["MensagemCadastroInvalido"] = "Usuario não cadastrado";
                return RedirectToAction("CadastroUsuario");
            }
        }

        IHttpContextAccessor HttpContextAccessor;
        public UsuarioController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public IActionResult ExercicioAerobico()
        {
            return View();

        }
        public IActionResult ExercicioAnaerobico()
        {
            return View();

        }
        public IActionResult DietaH()
        {
            return View();

        }
        public IActionResult DietaD()
        {
            return View();

        }
        public IActionResult CalcularIMC(UsuarioModel usuario)
        {
            ViewBag.abaixo = "Voce está abaixo do peso";
            ViewBag.ideal = "Voce está no peso ideal";
            ViewBag.acima = "Voce está acima do peso";
            ViewBag.obeso = "Voce está obeso";
            // double atualizar = usuario.CalcularIMC();

            //if (atualizar!=0)
            // {
            //     TempData["MensagemCadastroSucesso"] = "Usuario cadastrado com sucesso!";
            //     return RedirectToAction("UsuarioLogado");
            // }
            // else
            // {
            //     TempData["MensagemCadastroInvalido"] = "Usuario não cadastrado";
            //     return RedirectToAction("UsuarioLogado");
            // }

            return RedirectToAction("UsuarioLogado");
        }

    }
 }

