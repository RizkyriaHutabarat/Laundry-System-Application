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
    public partial class FormLaporan : Form
    {
        DBConfig dbConfig = new DBConfig(); 
        public FormLaporan()
        {
            InitializeComponent();
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DBConfig dbConfig = new DBConfig();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string query = "SELECT * FROM tb_transaksi";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTransaksi formTransaksi = new FormTransaksi();
            formTransaksi.Show();
        }

        public void TableDataLoad()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_transaksi",conn); 
                DataTable AllDataTable = new DataTable();   
                using(MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    adapter.Fill(AllDataTable);
                }  
                dataGridView1.DataSource= AllDataTable; 

            }
        }
        private void FormLaporan_Load(object sender, EventArgs e)
        {
            
        }

        void TableData()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `tb_transaksi` WHERE 1", conn);
                DataTable AllDataTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    adapter.Fill(AllDataTable);
                }
                dataGridView1.DataSource = AllDataTable;

            }
        }
        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
