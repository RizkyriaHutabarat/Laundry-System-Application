using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Data.SqlClient;

namespace Laundry_TB
{
    internal class DBConfig
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db_laundry");

        public MySqlConnection getConnection
        {
            get { return connection; }
        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
        public void ExecuteQuery(string query)
        {
            MySqlCommand command= new MySqlCommand(query,connection); 
            command.ExecuteNonQuery();
        }

        public object ShowData(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();  
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            object bebas = ds.Tables[0];
            return bebas;
        }
    }
}
