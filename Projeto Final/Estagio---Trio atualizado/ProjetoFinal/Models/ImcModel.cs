using Microsoft.AspNetCore.Http;
using ProjetoFinal.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class ImcModel
    {
        public int Id { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string Faixa { get; set; }

        public float imc { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public bool InserirDados()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO CADASTRO(PESO,ALTURA) VALUES ('{Peso}', '{Altura}') WHERE Id ='{id_usuario_logado}'";
            Util.DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
            return true;
        }
        public float CalcularIMC()
        {
            string sql = $"SELECT ALTURA, PESO FROM CADASTRO WHERE Id='{Id}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);


            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Altura = float.Parse(dt.Rows[0]["ALTURA"].ToString()); //dados para sessao
                    Peso = float.Parse(dt.Rows[0]["PESO"].ToString()); //dados para sessao
                }
            }
            Math.Round(imc, 1);
            imc = Peso / (Altura * Altura);
           
            return imc;
                
        }
    }
}
