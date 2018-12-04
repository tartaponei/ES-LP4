using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class PressaoController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public PressaoController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public IActionResult Usuario_Logado(int cpf)
        {
            PressaoModel objPressao = new PressaoModel(HttpContextAccessor);
            ViewBag.listaPressao = objPressao.ListaPressao();
            return View();

        }
        [HttpPost]
        public IActionResult Usuario(PressaoModel formulario)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.InserirPressao();
                return RedirectToAction("UsuarioLogado");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirPressao(int Cpf)
        {
            PressaoModel objPressao = new PressaoModel(HttpContextAccessor);
            objPressao.Excluir(Cpf);
            return RedirectToAction("UsuarioLogado");
        }
    }
}