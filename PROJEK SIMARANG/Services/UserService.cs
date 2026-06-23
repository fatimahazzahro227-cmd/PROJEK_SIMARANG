using System;
using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class UserService
    {
        public User Login(string username, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT u.id_user, u.nama_user, u.username, u.no_hp, 
                                        u.alamat, u.status_akun, u.id_role, r.nama_role
                                 FROM users u
                                 JOIN role r ON u.id_role = r.id_role
                                 WHERE u.username = @username 
                                 AND u.password = @password 
                                 AND u.status_akun = 'Aktif'";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),
                                NamaUser = reader.GetString(1),
                                Username = reader.GetString(2),
                                NoHp = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Alamat = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                StatusAkun = reader.GetString(5),
                                RoleId = reader.GetInt32(6),
                                NamaRole = reader.GetString(7)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Tambahkan u.password di bawah ini ↓
                string query = @"SELECT u.id_user, u.nama_user, u.username, u.password, 
                                u.no_hp, u.alamat, u.tanggal_daftar,
                                u.status_akun, u.id_role, r.nama_role
                         FROM users u
                         JOIN role r ON u.id_role = r.id_role
                         ORDER BY u.id_user";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            UserId = reader.GetInt32(0),
                            NamaUser = reader.GetString(1),
                            Username = reader.GetString(2),
                            Password = reader.IsDBNull(3) ? "" : reader.GetString(3), 
                            NoHp = reader.IsDBNull(4) ? "" : reader.GetString(4),     
                            Alamat = reader.IsDBNull(5) ? "" : reader.GetString(5),   
                            TanggalDaftar = reader.GetDateTime(6),                    
                            StatusAkun = reader.GetString(7),                         
                            RoleId = reader.GetInt32(8),                              
                            NamaRole = reader.GetString(9)                         
                        });
                    }
                }
            }
            return list;
        }

        public void Add(User u)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO users 
                                 (nama_user, username, password, no_hp, alamat, status_akun, id_role)
                                 VALUES (@nama, @username, @password, @nohp, @alamat, @status, @roleid)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", u.NamaUser);
                    cmd.Parameters.AddWithValue("username", u.Username);
                    cmd.Parameters.AddWithValue("password", u.Password);
                    cmd.Parameters.AddWithValue("nohp", u.NoHp ?? "");
                    cmd.Parameters.AddWithValue("alamat", u.Alamat ?? "");
                    cmd.Parameters.AddWithValue("status", u.StatusAkun);
                    cmd.Parameters.AddWithValue("roleid", u.RoleId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(User u)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE users SET 
                                 nama_user = @nama, username = @username,
                                 no_hp = @nohp, alamat = @alamat,
                                 status_akun = @status, id_role = @roleid
                                 WHERE id_user = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", u.NamaUser);
                    cmd.Parameters.AddWithValue("username", u.Username);
                    cmd.Parameters.AddWithValue("nohp", u.NoHp ?? "");
                    cmd.Parameters.AddWithValue("alamat", u.Alamat ?? "");
                    cmd.Parameters.AddWithValue("status", u.StatusAkun);
                    cmd.Parameters.AddWithValue("roleid", u.RoleId);
                    cmd.Parameters.AddWithValue("id", u.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM users WHERE id_user = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}