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
        private static string database = "projeto";
        private static string user = "root";
        private static string password = "";
        private string connectionString = $"Server={server};Port={3306};Database={database};Uid={user};Pwd={password};SslMode=none";
        private MySqlConnection connection;

        public DAL()
        {

            connection = new MySqlConnection(connectionString);
            connection.Open();



        }

        //executa SELECTs
        public DataTable RetDataTable(string sql)
        {


            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);



            return dataTable;

        }

        //executa INSERTs, UPDATEs E DELETEs
        public void ExecutarComandoSql(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();

        }

    }
}

