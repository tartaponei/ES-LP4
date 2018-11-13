using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula1307.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula1307.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CarregaLista();
            return View();
        }

        public void CarregaLista()
        {
            HomeModel hm = new HomeModel();
            ViewBag.Lista = hm.listarNomes();

        }
    }
}