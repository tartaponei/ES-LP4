using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ProjetoFinal.Util;
using Microsoft.AspNetCore.Http;

namespace ProjetoFinal.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Cpf { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public string Sexo { get; set; }
        public string Condicao { get; set; }
        public float Pressao { get; set; }
        public float Nivel_glicemico { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public float Valor { get; set; }



        public bool Autenticar()
        {
            string sql = $"SELECT ID, NOME, DATA_NASCIMENTO FROM CADASTRO WHERE EMAIL='{Email}'" +
                $" AND SENHA='{Senha}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString()); //dados para sessao
                    Nome = dt.Rows[0]["NOME"].ToString(); //dados para sessao
                    Data_Nascimento = DateTime.Parse(dt.Rows[0]["DATA_NASCIMENTO"].ToString());
                    return true;
                }
            }
            return false;
        }
        public bool Cadastrar()
        {
            string sql = $"INSERT INTO CADASTRO(NOME,EMAIL,SENHA,CPF,ALTURA,PESO,SEXO,CONDICAO,DATA_NASCIMENTO,PRESSAO,NIVEL_GLICEMICO) VALUES ('{Nome}','{Email}','{Senha}','{Cpf}','{Altura}','{Peso}','{Sexo}','{Condicao}','{Data_Nascimento}','{Pressao}','{Nivel_glicemico}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
            return true;
        }  
        public UsuarioModel()
        {
        } 
        public bool perfil()
        {
            string sql = $"SELECT ID, NOME, DATA_NASCIMENTO, CODICAO,ALTURA,PESO FROM CADASTRO WHERE ID='{Id}' INNER JOIN IMC" +
                $" VALOR WHERE ID='{Id}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString()); //dados para sessao
                    Nome = dt.Rows[0]["NOME"].ToString(); //dados para sessao
                    Data_Nascimento = DateTime.Parse(dt.Rows[0]["DATA_NASCIMENTO"].ToString());
                    Condicao = dt.Rows[0]["CONDICAO"].ToString(); //dados para sessao
                    Altura = float.Parse(dt.Rows[0]["ALTURA"].ToString()); //dados para sessao
                    Peso = float.Parse(dt.Rows[0]["Peso"].ToString()); //dados para sessao
                    Valor = float.Parse(dt.Rows[0]["VALOR"].ToString()); //dados para sessao
                    return true;
                }
            }
            return false;
        }
        

        
    }
}
    
