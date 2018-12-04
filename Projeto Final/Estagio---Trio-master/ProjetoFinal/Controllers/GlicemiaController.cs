using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class GlicemiaController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public GlicemiaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public IActionResult Usuario_logado(int cpf)
        {
            GlicemiaModel objGlicemia = new GlicemiaModel(HttpContextAccessor);
            ViewBag.listaGlicemia = objGlicemia.ListaGlicemia();
            return View();

        }
        [HttpPost]
        public IActionResult Usuario(GlicemiaModel formulario)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.InserirGlicemia();
                return RedirectToAction("UsuarioLogado");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirUsuario(int Cpf)
        {
            GlicemiaModel objGlicemia = new GlicemiaModel(HttpContextAccessor);
            objGlicemia.Excluir(Cpf);
            return RedirectToAction("Usuario");
        }

    }
}