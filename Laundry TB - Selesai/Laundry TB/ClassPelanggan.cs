using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundry_TB
{
    internal class ClassPelanggan
    {
        public string Name { get; set; }    
        public string Berat { get; set; }
        public string Jenis { get; set; }
        public string Harga { get; set; }   
        public string HargaTotal { get; set; }
        public DateTime Tanggal_Pengambilan { get; set; }

        public ClassPelanggan(string nama,string berat,string jenis,string harga,string hargatotal,DateTime tanggal_pengambilan)
        {
            Name = nama;
            Berat = berat;
            Jenis = jenis;
            Harga = harga;
            HargaTotal = hargatotal;
            Tanggal_Pengambilan = tanggal_pengambilan;
        }



    }
}
