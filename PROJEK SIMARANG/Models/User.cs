using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string NamaUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NoHp { get; set; }
        public string Alamat { get; set; }
        public DateTime TanggalDaftar { get; set; }
        public string StatusAkun { get; set; }
        public int RoleId { get; set; }
        public string NamaRole { get; set; }
    }
}
