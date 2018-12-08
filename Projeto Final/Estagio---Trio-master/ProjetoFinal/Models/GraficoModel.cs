using Microsoft.AspNetCore.Http;
using ProjetoFinal.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class GraficoModel
    {
        

        public string Valor { get; set; }
        public int Id { get; set; }
        public int Nivel_glicemico { get; set; }
        [Required(ErrorMessage = "Informe o nível glicêmico!")]
        public int Pressao { get; set; }
        [Required(ErrorMessage = "Informe a pressao!")]
        public string Data_cadastroG{ get; set; }
        public string Data_cadastroP { get; set; }
        [Required(ErrorMessage = "Informe a Data!")]
        public string Condicao { get; set; }



        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public GraficoModel()
        {

        }

        //Recebe o contexto para acesso às variáveis de sessão.
        public GraficoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<GraficoModel> ListaGrafico()
        {
            List<GraficoModel> lista = new List<GraficoModel>();
            GraficoModel item;

            //Utilizado pela View Extrato
            string filtro = "";

            if (Data_cadastroP==" " && Data_cadastroG==" ")
            {
                filtro += $" and g.data_cadastroG,p.data_cadastroP >='{DateTime.Parse(Data_cadastroG).ToString("yyyy/MM/dd")}','{DateTime.Parse(Data_cadastroP).ToString("yyyy/MM/dd")}' ";
            }

            if (Condicao != null)
            {
                if (Condicao == "H")
                {
                    filtro += $" and p.pressao ='{Condicao}' ";
                }
               else if (Condicao == "D")
                {
                    filtro += $" and g.Nivel_glicemico ='{Condicao}' ";
                }
               else if (Condicao == "P" )
                {
                    filtro += $" and p.pressao, g.Nivel_glicemico ='{Condicao}' ";
                }
            }

            if (Id != 0)
            {
                filtro += $" and t.Id ='{Id}' ";
            }
            //Fim

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "select Condicao,Id" +
                        " from Cadastro as c inner join  Pressao as p" +
                        " on p.pressao,p.data_cadastroP inner join Glicemia as g " +
                        " on g.Nivel_glicemico,g.data_cadastroG" +
                        $" where c.Id = {id_usuario_logado} {filtro}order by p.data_cadastroP desc limit 2";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GraficoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nivel_glicemico = int.Parse(dt.Rows[i]["Nivel_glicemico"].ToString());
                item.Data_cadastroP = DateTime.Parse(dt.Rows[i]["data_cadastroP"].ToString()).ToString("dd/MM/yyyy");
                item.Data_cadastroG = DateTime.Parse(dt.Rows[i]["data_cadastroG"].ToString()).ToString("dd/MM/yyyy");
                item.Condicao = dt.Rows[i]["condicao"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public GraficoModel CarregarRegistro(int? id)
        {
            GraficoModel item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "select Condicao,Id" +
                        " from Cadastro as c inner join  Pressao as p" +
                        " on p.pressao,p.data_cadastroP inner join Glicemia as g " +
                        " on g.Nivel_glicemico,g.data_cadastroG" +
                        $" where c.Id  = {id_usuario_logado} and t.id='{id}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item = new GraficoModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Nivel_glicemico = int.Parse(dt.Rows[0]["Nivel_glicemico"].ToString());
            item.Data_cadastroP = DateTime.Parse(dt.Rows[0]["data_cadastroP"].ToString()).ToString("dd/MM/yyyy");
            item.Data_cadastroG = DateTime.Parse(dt.Rows[0]["data_cadastroG"].ToString()).ToString("dd/MM/yyyy");
            item.Condicao = dt.Rows[0]["condicao"].ToString();

            return item;
        }

        public void Insert()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "";
            if (Id == 0)
            {
                if (Condicao == "D")
                {
                    sql = "INSERT INTO GLICEMIA (NIVEL_GLICEMICO,DATA_CADASTRO) " +
                       $" VALUES('{Nivel_glicemico}','{DateTime.Parse(Data_cadastroG).ToString("yyyy/MM/dd")}')";

                }
                else if(Condicao== "H")
                {
                    sql = "INSERT INTO PRESSAO (PRESSAO,DATA_CADASTRO) " +
                    $" VALUES('{Pressao}','{DateTime.Parse(Data_cadastroP).ToString("yyyy/MM/dd")}')";
                }
                else if( Condicao =="P")
                {
                    sql = "INSERT INTO GLICEMIA (NIVEL_GLICEMICO,DATA_CADASTRO) " +
                     $" VALUES('{Nivel_glicemico}','{DateTime.Parse(Data_cadastroG).ToString("yyyy/MM/dd")}') inner join PRESSAO (PRESSAO,DATA_CADASTRO) " +
                    $" VALUES('{Pressao}','{DateTime.Parse(Data_cadastroP).ToString("yyyy/MM/dd")}') ";
                }
              
            }
            else
            {
                if (Condicao == "D")
                {
                    sql = $"UPDATE GLICEMIA SET NIVEL_GLICEMIA,DATA_CADASTRO='{Nivel_glicemico}','{DateTime.Parse(Data_cadastroG).ToString("yyyy/MM/dd")}', " +
                      $" NIVEL_GLICEMICO ='{Nivel_glicemico}', " +
                      $" DATA_CADASTROG='{Data_cadastroG}', " +
                      $" WHERE USUARIO_ID='{id_usuario_logado}' AND ID='{Id}'";

                }
                else if (Condicao == "H")
                {
                    sql = $"UPDATE PRESSAO SET PRESSAO,DATA_CADASTRO='{Pressao}','{DateTime.Parse(Data_cadastroP).ToString("yyyy/MM/dd")}', " +
                    $"PRESSAO ='{Pressao}', " +
                    $" DATA_ CADASTROP='{Data_cadastroP}', " +
                    $" WHERE USUARIO_ID='{id_usuario_logado}' AND ID='{Id}'";
                }
                else if (Condicao == "P")
                {
                    sql = $"UPDATE GLICEMIA SET NIVEL_GLICEMICO,DATA_CADASTROGG='{Nivel_glicemico}','{DateTime.Parse(Data_cadastroG).ToString("yyyy/MM/dd")}', inner join PRESSAO as p" +
                    $" on p.PRESSAO, p.DATA_CADASTROP  ='{Pressao}','{DateTime.Parse(Data_cadastroP).ToString("yyyy/MM/dd")}, " +
                    $" WHERE USUARIO_ID='{id_usuario_logado}' AND ID='{Id}'";
                }
            
            }

            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

        public void Excluir(int id)
        {
            new DAL().ExecutarComandoSql("DELETE FROM TRANSACAO WHERE ID = " + id);
        }
    }

    public class Dashboard
    {
        public string Data_cadastroG { get; set; }
        public string Data_cadastroP { get; set; }
        public int Nivel_glicemico { get; set; }
        public string Pressao { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public Dashboard()
        {

        }

        //Recebe o contexto para acesso às variáveis de sessão.
        public Dashboard(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<Dashboard> RetornarDadosGraficoLine()
        {
            List<Dashboard> lista = new List<Dashboard>();
            Dashboard item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");

            string sql = "select Condicao,Id" +
                        " from Cadastro as c inner join  Pressao as p" +
                        " on p.pressao,p.data_cadastroP inner join Glicemia as g " +
                        " on g.Nivel_glicemico,g.data_cadastroG" +
                        $" where c.Id ={id_usuario_logado}";
            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Dashboard();
                item.Pressao = (dt.Rows[i]["Pressao"].ToString());
                item.Data_cadastroP =(dt.Rows[i]["p.data_cadastroP"].ToString());
                item.Nivel_glicemico = int.Parse(dt.Rows[i]["Nivel_glicemico"].ToString());
                item.Data_cadastroG =(dt.Rows[i]["g.data_cadastroG"].ToString());
              
                lista.Add(item);
            }
            return lista;
        }
    }
}
