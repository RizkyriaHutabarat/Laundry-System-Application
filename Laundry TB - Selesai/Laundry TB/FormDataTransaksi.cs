using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry_TB
{
    public partial class FormDataTransaksi : Form
    {
        public FormDataTransaksi()
        {
            InitializeComponent();
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            string host = "localhost";
            string user = "root";
            string password = "";
            string database = "db_laundry";
            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            string query = "SELECT * FROM tb_transaksi";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


    }
}
