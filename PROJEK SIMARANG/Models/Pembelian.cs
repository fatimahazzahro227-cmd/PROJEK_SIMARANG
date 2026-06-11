using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class Pembelian
    {
        public int PembelianId { get; set; }
        public DateTime TanggalPembelian { get; set; }
        public string StatusPembelian { get; set; }
        public int UserId { get; set; }
        public string NamaUser { get; set; }
        public int SupplierId { get; set; }
        public string NamaSupplier { get; set; }
        public decimal TotalPembelian { get; set; }
    }
}
