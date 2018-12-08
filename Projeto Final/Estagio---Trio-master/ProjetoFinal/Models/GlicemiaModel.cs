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
        public int Id { get; set; }
        public int Nivel_glicemico { get; set; }
        public string Data_cadastro { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public GlicemiaModel()
        {
        }

        
        public GlicemiaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public bool InserirGlicemia()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO GLICEMIA(NIVEL_GLICEMICO,DATA_CADASTRO) VALUES ('{Nivel_glicemico}', '{Data_cadastro}') WHERE Id ='{id_usuario_logado}'";
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
            string sql = $"SELECT ID,Nivel_GLICEMICO, DATA_CADASTRO FROM Nivel_Glicemico WHERE ID='{id_usuario_logado}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
           {
                item = new GlicemiaModel();
               
                item.Nivel_glicemico = int.Parse(dt.Rows[i]["NIVEL_GLICEMICO"].ToString());
                lista.Add(item);

            }
            return lista;
        }
       
        public void Excluir(int Id)
        {
            new DAL().ExecutarComandoSql("DELETE FROM NIVEL_GLICEMICO WHERE Id=" + Id);
        }

       
    }
 }
