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

namespace Laundry_TB
{
    public partial class FormRegister : Form
    {
        
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBConfig dbConfig = new DBConfig();
            
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            MySqlCommand command = new MySqlCommand("INSERT INTO `tb_register`(`nama`, `username`, `email`, `password`, `no_hp`, `alamat`) VALUES (@nama,@username,@email,@pass,@nohp,@alamat)", dbConfig.GetConnection());
            dbConfig.openConnection();
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = textNama.Text;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = textUsername.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textEmail.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textPass.Text;
            command.Parameters.Add("@nohp", MySqlDbType.VarChar).Value = textNohp.Text;
            command.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = textAlamat.Text;

            dbConfig.openConnection();
            
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Akun Berhasil Ditambahkan");
            }
            else
            {
                MessageBox.Show("Error");
            }

            dbConfig.openConnection();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
