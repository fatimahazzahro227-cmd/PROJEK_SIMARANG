using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class Pelanggan
    {
        public int PelangganId { get; set; }
        public string NamaPelanggan { get; set; }
        public string Alamat { get; set; }
        public string NoTelepon { get; set; }
        public string Email { get; set; }
        public string JenisUsaha { get; set; }
        public DateTime TanggalDaftar { get; set; }
    }
}
