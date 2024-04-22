using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class DBConnection
    {
        private string conn = string.Empty;
        SqlConnection connection = new SqlConnection();
        public DBConnection(string conn)
        {
            this.conn = conn;
            connection = new SqlConnection(conn);
        }

        public void KetNoi()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void DongKetNoi()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable GetAllChuyenBay()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();

                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllChuyenBay()", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
            return table;
        }
        public List<MayBay> GetAllMayBay()
        {
            List<MayBay> list = new List<MayBay>();
            try
            {
                KetNoi();

                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllMayBay()", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maMB = reader["MaMB"].ToString();
                    string tenMB = reader["TenMB"].ToString();
                    MayBay mb = new MayBay(maMB, tenMB);
                    list.Add(mb);
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
            return list;
        }

        public void ThemChuyenBay(ChuyenBay cb)
        {
            try
            {
                KetNoi();

                SqlCommand command = new SqlCommand($"AddNewChuyenBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DiemXuatPhat", cb.XuatPhat);
                command.Parameters.AddWithValue("@DiemDen", cb.Den);
                command.Parameters.AddWithValue("@MaMB", cb.MB.MaMB);
                command.Parameters.AddWithValue("@NgayBay", cb.NgayBay.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@PhutBay", cb.PhutBay);
                command.Parameters.AddWithValue("@GioHaCanh", cb.CatCanh);
                command.Parameters.AddWithValue("@GioCatCanh", cb.HaCanh);
                command.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        public void SuaChuyenBay(ChuyenBay cb)
        {
            try
            {
                KetNoi();

                SqlCommand command = new SqlCommand($"UpdateChuyenBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MaCB", cb.MaCB);
                command.Parameters.AddWithValue("@DiemXuatPhat", cb.XuatPhat);
                command.Parameters.AddWithValue("@DiemDen", cb.Den);
                command.Parameters.AddWithValue("@MaMB", cb.MB.MaMB);
                command.Parameters.AddWithValue("@NgayBay", cb.NgayBay.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@PhutBay", cb.PhutBay);
                command.Parameters.AddWithValue("@GioHaCanh", cb.CatCanh);
                command.Parameters.AddWithValue("@GioCatCanh", cb.HaCanh);
                command.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }


        public void XoaChuyenBay(string maCB)
        {
            try
            {
                KetNoi();

                SqlCommand command = new SqlCommand($"DeleteChuyenBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MaCB", maCB);
                command.ExecuteNonQuery();
                MessageBox.Show("Xoa thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        public float TongTienVeDaBan()
        {
            float TongTienVe = 0;

            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("SELECT dbo.TongTienVeDaBan() AS TongTienVeDaBan", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("TongTienVe")))
                    {
                        TongTienVe = reader.GetFloat(reader.GetOrdinal("TongTienVe"));
                        MessageBox.Show(TongTienVe.ToString());
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }

            return TongTienVe;
        }
        public void GenerateMa(out string MaVe)
        {
            MaVe = "";

            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("GenerateMa", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MaVe", SqlDbType.VarChar, 4);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                MaVe = cmd.Parameters["@MaVe"].Value.ToString();
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }
        public void ThemVeChuyenBay(string TinhTrang, DateTime NgayDat, DateTime NgayBay, string BienLai, TimeSpan GioBay, string HoTen, DateTime NgaySinh, string GioiTinh, string SDT, string Email, TimeSpan GioHaCanh, TimeSpan GioCatCanh, string MaCB, string MaHL, string MaLoai)
        {
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("ThemVeChuyenBay", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);
                cmd.Parameters.AddWithValue("@NgayDat", NgayDat);
                cmd.Parameters.AddWithValue("@NgayBay", NgayBay);
                cmd.Parameters.AddWithValue("@BienLai", BienLai);
                cmd.Parameters.AddWithValue("@GioBay", GioBay);
                cmd.Parameters.AddWithValue("@HoTen", HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@GioHaCanh", GioHaCanh);
                cmd.Parameters.AddWithValue("@GioCatCanh", GioCatCanh);
                cmd.Parameters.AddWithValue("@MaCB", MaCB);
                cmd.Parameters.AddWithValue("@MaHL", MaHL);
                cmd.Parameters.AddWithValue("@MaLoai", MaLoai);
                SqlParameter MaVeParam = new SqlParameter("@MaVe", SqlDbType.VarChar, 4);
                MaVeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(MaVeParam);
                cmd.ExecuteNonQuery();
                string MaVe = cmd.Parameters["@MaVe"].Value.ToString();

                MessageBox.Show("Mã vé: " + MaVe);
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        public DataTable SearchFlights(DateTime ngayBay, decimal? giaTu, decimal? giaDen)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("TimVeBay", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NgayBay", SqlDbType.Date).Value = ngayBay;
                cmd.Parameters.Add("@GiaTu", SqlDbType.Decimal).Value = (object)giaTu ?? DBNull.Value;
                cmd.Parameters.Add("@GiaDen", SqlDbType.Decimal).Value = (object)giaDen ?? DBNull.Value;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
            return dt;
        }
    }
}
