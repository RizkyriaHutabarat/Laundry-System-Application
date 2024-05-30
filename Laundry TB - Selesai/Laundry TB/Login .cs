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

namespace Laundry_TB
{
    public partial class MenuUtama : Form
    {
        public MenuUtama()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to quit ?",
            "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBConfig conn = new DBConfig();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand();
                String query = "SELECT * FROM tb_user WHERE username = @username AND password = @password";

                command.CommandText = query;
                command.Connection = conn.GetConnection();

                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                //if the username and the password exists
                if (table.Rows.Count > 0)
                {
                    //show the main form
                    this.Hide();
                    FormMenuUtama formMenuUtama = new FormMenuUtama();
                    formMenuUtama.Show();
                    
                }
                else
                {
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter your username to Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox2.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("This username or password does not exists", "Wrong Username/Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {

        }
    }
}
