using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class Penjualan
    {
        public int PenjualanId { get; set; }
        public DateTime TanggalPenjualan { get; set; }
        public string OpsiPenyerahan { get; set; }
        public string StatusLogistik { get; set; }
        public string AlamatPengiriman { get; set; }
        public int PelangganId { get; set; }
        public string NamaPelanggan { get; set; }
        public int MetodePembayaranId { get; set; }
        public string NamaMetode { get; set; }
        public int UserId { get; set; }
        public string NamaUser { get; set; }
        public decimal TotalPenjualan { get; set; }
    }
}
