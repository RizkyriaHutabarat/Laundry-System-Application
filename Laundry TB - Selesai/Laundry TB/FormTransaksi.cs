using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Laundry_TB
{
    public partial class FormTransaksi : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataSet ds;
        String nama = "";
        FormLaporan formLaporan;
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db_laundry");

        public FormTransaksi()
        {
            InitializeComponent();
            this.formLaporan = new FormLaporan();
            comboBox2.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "KARPET")
            {
                textHarga.Text = "50000";
            }
            else if (comboBox1.SelectedItem == "PAKAIAN")
            {
                textHarga.Text = "6000";
            }
            else if (comboBox1.SelectedItem == "BONEKA")
            {
                textHarga.Text = "25000";
            }
            else if (comboBox1.SelectedItem == "SELIMUT")
            {
                textHarga.Text = "15000";
            }
            else if (comboBox1.SelectedItem == "SEPATU")
            {
                textHarga.Text = "15000";
            }
        }

        private void btnproses_Click(object sender, EventArgs e)
        {
            int c = 5000;
            int hasil = int.Parse(textHarga.Text) * int.Parse(textBerat.Text);

            textTotal.Text = System.Convert.ToString(hasil);
            if (radioButton2.Checked == true)
            {
                textTotal.Text = System.Convert.ToString(hasil + c);
            }
        }

        private void btnhitung_Click(object sender, EventArgs e)
        {
            int kembalian = int.Parse(textUangPelanggan.Text) - int.Parse(textTotal.Text);

            textKembalian.Text = System.Convert.ToString(kembalian);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBerat.Text = "";
            textHarga.Text = "";
            textTotal.Text = "";
            comboBox1.Text = "";
            textUangPelanggan.Text = "";
            textKembalian.Text = "";
            dateTimePicker1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

 
           
        private void btnsimpan_Click(object sender, EventArgs e)
        {
            DBConfig dbConfig = new DBConfig();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `tb_transaksi`(`nama`, `berat`, `jenis`, `harga`, `harga_total`) VALUES (@nama,@berat,@jenis,@harga,@harga_total)", dbConfig.GetConnection());
            dbConfig.openConnection();
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = comboBox2.Text;
            command.Parameters.Add("@berat", MySqlDbType.VarChar).Value = textBerat.Text;
            command.Parameters.Add("@jenis", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@harga", MySqlDbType.VarChar).Value = textHarga.Text;
            command.Parameters.Add("@harga_total", MySqlDbType.VarChar).Value = textTotal.Text;
          

            dbConfig.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Berhasil Ditambahkan");
            }
            else
            {
                MessageBox.Show("Error");
            }

            dbConfig.openConnection();

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void textNama_TextChanged(object sender, EventArgs e)
        {
            DBConfig dbConfig = new DBConfig();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db_laundry");
            try
            {
                comboBox2.Items.Clear();    
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT nama FROM tb_register", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }
                connection.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
