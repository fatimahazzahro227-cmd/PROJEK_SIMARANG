using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class Produk
    {
        public int ProdukId { get; set; }
        public string NamaProduk { get; set; }
        public string Satuan { get; set; }
        public decimal HargaBeli { get; set; }
        public decimal HargaJual { get; set; }
        public string Deskripsi { get; set; }
        public string StatusProduk { get; set; }
        public int KategoriProdukId { get; set; }
        public string NamaKategori { get; set; }
    }
}
