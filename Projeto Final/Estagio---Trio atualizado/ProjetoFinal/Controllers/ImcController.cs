using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ImcController : Controller
    {
        public IActionResult CalcularIMC(ImcModel Imc)
        {
            double CalcularIMC = Imc.CalcularIMC();
            if (CalcularIMC != 0) { 
            var imc = new ImcModel();
                {
                   // ViewData["mensagem"] = "ERROOOOOO";
                    //if (imc.CalcularIMC() >30)
                    //{
                    //    imc.Faixa = "vc esta abaixo do peso";
  
                    //}
                    /*else if (imc.CalcularIMC() >= 18.5 && imc.CalcularIMC() >= 24.9)
                    {
                        imc.Faixa = "vc no peso ideal";

                    }
                    else if (imc.CalcularIMC() >= 25 && imc.CalcularIMC() <= 29.9)
                    {
                        imc.Faixa = "vc esta sobre peso";

                    }
                    else if (imc.CalcularIMC() > 40)
                    {
                        imc.Faixa = "vc esta acima do peso";
                    }*/
                }
                



            }
            return View(Imc);


        }
        public IActionResult Imc()
        {
            var imc = new ImcModel();
           
            if (imc.CalcularIMC() <18.5000)
                 {
                  imc.Faixa = "abaixo";
                 }
            else if (imc.CalcularIMC() >= 18.5000 && imc.CalcularIMC() >= 24.9000)
                {
                    imc.Faixa = "ideal";
                }
            else if (imc.CalcularIMC() >= 25.0000 && imc.CalcularIMC() < 29.9000)
                {
                    imc.Faixa = "sobrepeso";
                }
            else if (imc.CalcularIMC() >= 40.000)
                {
                    imc.Faixa = "obeso";
                }
                
             else 
                    imc.Faixa = "ERROOOOO";

            ViewData["Faixa"] = imc.Faixa;
            return View();
        }
            
        }
    }
