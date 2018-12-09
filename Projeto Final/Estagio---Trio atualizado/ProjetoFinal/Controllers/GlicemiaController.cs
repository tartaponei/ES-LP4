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
        public IActionResult Glicemia()
        {
            return View();
        }

        IHttpContextAccessor HttpContextAccessor;
        public GlicemiaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public IActionResult Usuario_logado(int Id)
        {
            GlicemiaModel objGlicemia = new GlicemiaModel(HttpContextAccessor);
            ViewBag.listaGlicemia = objGlicemia.ListaGlicemia();
            return View();

        }
        [HttpPost]
        public IActionResult Glicemia(GlicemiaModel formulario)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.InserirGlicemia();
                return RedirectToAction("Glicemia");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirGlicemia(int Id)
        {
            GlicemiaModel objGlicemia = new GlicemiaModel(HttpContextAccessor);
            objGlicemia.Excluir(Id);
            return RedirectToAction("Glicemia");
        }
    
    }
}