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

namespace Laundry_TB
{
    public partial class FormMenuUtama : Form
    {
        FormTransaksi FormTransaksi;
        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void tRANSAKSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
        }

        private void fORMTRANSAKSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransaksi formTransaksi = new FormTransaksi();
            formTransaksi.Show();
        }

        private void lAPORANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan = new FormLaporan();
            formLaporan.ShowDialog();
        }

        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
