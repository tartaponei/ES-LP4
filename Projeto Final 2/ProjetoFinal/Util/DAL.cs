using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Util
{
    public class DAL
    {

        private static string server = "localhost";
        private static string port = "3307";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "root";
        private string connectionString = $"Server={server}; Port={port};Database{database}; Uid={user}; Pwd={password},SslMode=none";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        // executa selects no banco 

        public DataTable RetDataTable(string sql)
        {
            // formato de retorno dos dados do banco 
            System.Data.DataTable dt = new DataTable();
            //executa comandos em sql
            MySqlCommand command = new MySqlCommand(sql, connection);
            //tranforma os dados para gravar no DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dt);
            return dt;

        }
        //executa  INSERTs, DELETs, UPDATEs
        public void ExecutarComando(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}

