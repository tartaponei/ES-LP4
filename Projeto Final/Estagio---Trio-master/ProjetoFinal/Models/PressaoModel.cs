using Microsoft.AspNetCore.Http;
using ProjetoFinal.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class PressaoModel
        {


       

        public string Cpf { get; set; }
        public float Pressao { get; set; }
        public DateTime data_cadastro { get; set; }


        IHttpContextAccessor HttpContextAccessor;

        public PressaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public PressaoModel()
        {
        }

        public bool InserirPressao()
        {



            string sql = $"INSERT INTO PRESSAO(PRESSAO,DATA_CADASTRO) VALUES ('{Pressao}', '{data_cadastro}') WHERE CPF ='{Cpf}'";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
            return true;
        }
        public List<PressaoModel> ListaPressao()
        {
            List<PressaoModel> lista = new List<PressaoModel>();
            PressaoModel item;

            // pegar iddo usuario logado

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            string sql = $"SELECT PRESSAO FROM PRESSAO WHERE CPF='{Cpf}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
               item = new PressaoModel();
               item.Cpf = (dt.Rows[i]["CPF"].ToString());
               item.Pressao = int.Parse(dt.Rows[i]["NIVEL_GLICEMICO"].ToString());
               lista.Add(item);

            }
            return lista;
        }
        public void AtualizarDados()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO PRESSAO(PRESSAO)VALUES( '{Pressao}')";
            DAL objDAO = new DAL();
            objDAO.ExecutarComandoSql(sql);
        }
        public void Excluir(int Cpf)
        {
            new DAL().ExecutarComandoSql("DELETE FROM Pressao WHERE CPF=" + Cpf);
        }

    }
}
