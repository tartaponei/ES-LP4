using Microsoft.AspNetCore.Http;
using ProjetoFinal.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class GlicemiaModel
    {
        public string Cpf { get; set; }
        public float Nivel_glicemico { get; set; }
        public DateTime data_cadastro { get; set; }


        IHttpContextAccessor HttpContextAccessor;

        public GlicemiaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public GlicemiaModel()
        {
        }

        public bool InserirGlicemia()
        {



            string sql = $"INSERT INTO NIVEL_GLICEMICO(NIVEL_GLICEMICO,DATA_CADASTRO) VALUES ('{Nivel_glicemico}', '{data_cadastro}') WHERE CPF ='{Cpf}'";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
            return true;
        }
        public List<GlicemiaModel> ListaGlicemia()
        {
            List<GlicemiaModel> lista = new List<GlicemiaModel>();
            GlicemiaModel item;

            // pegar iddo usuario logado

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            string sql = $"SELECT CPF,Nivel_GLICEMICO FROM Nivel_Glicemico WHERE CPF='{Cpf}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
           {
                item = new GlicemiaModel();
                item.Cpf = (dt.Rows[i]["CPF"].ToString());
                item.Nivel_glicemico = int.Parse(dt.Rows[i]["NIVEL_GLICEMICO"].ToString());
                lista.Add(item);

            }
            return lista;
        }
        public void AtualizarDados()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO NIVEL_GLICEMICO(NIVEL_GLICEMICO)VALUES( '{Nivel_glicemico}')";
            DAL objDAO = new DAL();
            objDAO.ExecutarComandoSql(sql);
        }
        public void Excluir(int Cpf)
        {
            new DAL().ExecutarComandoSql("DELETE FROM NIVEL_GLICEMICO WHERE CPF=" + Cpf);
        }
    }
}
