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
            //Logoff => apagar sessão
            if (id == 0)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
            }

            return View();
        }
       
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CadastroUsuario()
        {
            return View();
        }
        public IActionResult PagUsuario()
        {
            return View();
        }
        public IActionResult Engorda()
        {
            return View();
        }

        //  public IActionResult PagUsuario(UsuarioModel usuario)
        //   {
        // return RedirectToAction("Login", "Usuario");
        //       return View();
        //   }

        public IActionResult Autenticar(UsuarioModel usuario)
        {

            //Adicionar nome do usuário no menu => sessão
            bool login = usuario.Autenticar();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MENSAGEMloginInvalido"] = "Usuario ou senha inválidos";
                return RedirectToAction("Login");
            }
        }
    }
  }
