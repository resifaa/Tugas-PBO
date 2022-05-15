using System;
using Npgsql;
using System.Data;
using System.Configuration;

namespace TugasSelect
{
    class pbotm
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=19042003;database=pbo;");
        }
        public bool ExecuteQuery(out bool info)

        {
            info = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from jenis_cucian";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;
            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=19042003;database=pbo;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into karyawan(id_categorie,jenis,deskripsi) values('1','cuci basah','menggunakan air')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update jenis_cucian set jenis = cuci kering, deskripsi = menggunakan larutan khusus where id_categorie = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from karyawan where id_categorie = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
    }
    class program_utama
    {
        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            pbotm dat = new pbotm();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("cucian masuk");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("cucian tidak masuk");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("insert sukses");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("update sukses");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("update gagal");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("delete sukses");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("delete gagal");
            }
        }
    }
}
