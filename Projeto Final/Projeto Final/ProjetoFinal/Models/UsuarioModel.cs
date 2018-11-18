using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ProjetoFinal.Util;

namespace ProjetoFinal.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public DateTime Data_nascimento { get; set; }

        public bool Autenticar()
        {
            string sql = $"SELECT  ID,NOME,DATA_NASCIMENTO FROM" +
                $"usuario where Email='{Email}' AND SENHA='{Senha}'";
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
    
