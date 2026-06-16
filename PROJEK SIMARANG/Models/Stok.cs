using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class Stok
    {
        public int StokId { get; set; }
        public int JumlahStok { get; set; }
        public int StokMinimum { get; set; }
        public DateTime TanggalUpdate { get; set; }
        public int ProdukId { get; set; }
        public string NamaProduk { get; set; }
        public string Satuan { get; set; }
        public string NamaKategori { get; set; }
        public int SelisihStok { get; set; }
        public string StatusStok { get; set; }
    }
}
