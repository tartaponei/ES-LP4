using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class UsuarioController : Controller
    {
       
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

            bool login = usuario.Autenticar();
            if (login)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MENSAGEMloginInvalido"] = "Usuario ou senha inválidos ";
                return RedirectToAction("Login");
            }
        }
    }
  }
