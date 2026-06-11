using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Helpers
{
    public static class SessionHelper
    {
        public static int UserId { get; set; }
        public static string NamaUser { get; set; }
        public static string Username { get; set; }
        public static int RoleId { get; set; }
        public static string NamaRole { get; set; }

        public static void Clear()
        {
            UserId = 0;
            NamaUser = string.Empty;
            Username = string.Empty;
            RoleId = 0;
            NamaRole = string.Empty;
        }
    }
}


