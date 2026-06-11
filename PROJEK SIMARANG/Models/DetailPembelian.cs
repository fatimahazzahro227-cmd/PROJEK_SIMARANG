using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class DetailPembelian
    {
        public int DetailPembelianId { get; set; }
        public int PembelianId { get; set; }
        public int ProdukId { get; set; }
        public string NamaProduk { get; set; }
        public decimal HargaBeli { get; set; }
        public int Jumlah { get; set; }
        public decimal Subtotal => Jumlah * HargaBeli;
    }
}
