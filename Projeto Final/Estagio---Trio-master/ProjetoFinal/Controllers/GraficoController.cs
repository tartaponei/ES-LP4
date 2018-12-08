using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class GraficoController : Controller
    {
       
        
            IHttpContextAccessor HttpContextAccessor;

            public GraficoController(IHttpContextAccessor httpContextAccessor)
            {
                HttpContextAccessor = httpContextAccessor;
            }

            public IActionResult Grafico()
            {
                GraficoModel objTransacao = new GraficoModel(HttpContextAccessor);
                ViewBag.ListaGrafico= objTransacao.ListaGrafico();
                return View();
            }

            [HttpPost]
            public IActionResult Registrar(GraficoModel formulario)
            {
                if (ModelState.IsValid)
                {
                    formulario.HttpContextAccessor = HttpContextAccessor;
                    formulario.Insert();
                    return RedirectToAction("Index");
                }

                return View();
            }

            [HttpGet]
            public IActionResult Registrar(int? id)
            {
                if (id != null)
                {
                    GraficoModel objTransacao = new GraficoModel(HttpContextAccessor);
                    ViewBag.Registro = objTransacao.CarregarRegistro(id);
                }
                ViewBag.ListaGrafico = new GlicemiaModel(HttpContextAccessor).ListaGlicemia();
                ViewBag.ListaPressao = new PressaoModel(HttpContextAccessor).ListaPressao();

                return View();
            }

            [HttpGet]
            public IActionResult Excluir(int id)
            {
                GraficoModel objTransacao = new GraficoModel(HttpContextAccessor);
                ViewBag.Registro = objTransacao.CarregarRegistro(id);
                return View();
            }


            [HttpGet]
            public IActionResult Excluirdados(int id)
            {
                GraficoModel objTransacao = new GraficoModel(HttpContextAccessor);
                objTransacao.Excluir(id);
                return RedirectToAction("UsuarioLogado");
            }

            [HttpGet]
            [HttpPost]
            public IActionResult Extrato(GraficoModel formulario)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                ViewBag.ListaGrafico = formulario.ListaGrafico();
                return View();
            }

            public IActionResult Dashboard()
            {
                List<Dashboard> lista = new Dashboard(HttpContextAccessor).RetornarDadosGraficoLine();
                string valores = "";
                string labels = "";
                string cores = "";
                var random = new Random();

                for (int i = 0; i < lista.Count; i++)
                {
                    valores += lista[i].Nivel_glicemico.ToString() + ",";
                    labels += "'" + lista[i].Data_cadastroG.ToString() + "',";
                    cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
                }

                ViewBag.Cores = cores;
                ViewBag.Labels = labels;
                ViewBag.Valores = valores;

                return View();
            }
        }
    }
