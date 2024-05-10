using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Imaging;

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
        //Su ly du lieu//
        public byte[] ImageToByteArray(Image img)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ImageFormat format = img.RawFormat;
                    img.Save(ms, format);
                    return ms.ToArray();
                }
            }
            catch 
            {
                throw new Exception("Please Input the PNG file!!");
            }
            return new byte[0];
        }
        public Image ByteArrayToImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        public byte[] ReadPdfFileToByteArray(string pdfFilePath)
        {
            // Check if the file exists
            if (!File.Exists(pdfFilePath))
            {
                throw new FileNotFoundException("The specified PDF file does not exist.", pdfFilePath);
            }

            // Read the PDF file content into a byte array
            byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);

            return pdfBytes;
        }

        public void DisplayPDFInWebBrowser(byte[] pdfData, ref WebBrowser webBrowser)
        {
            try
            {
                // Create a temporary file path
                string tempFilePath = Path.Combine(Path.GetTempPath(), "vemaybay.pdf");

                // Write the PDF byte array to a temporary file
                File.WriteAllBytes(tempFilePath, pdfData);

                // Check if the file was written successfully
                if (File.Exists(tempFilePath))
                {
                    // Navigate the WebBrowser control to the temporary file
                    webBrowser.Navigate(tempFilePath);
                }
                else
                {
                    MessageBox.Show("Error: Failed to write PDF data to temporary file.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //
        // Ket Noi
        //
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
        //
        // Chuyen Bay
        //

        public DataTable GetAllFlightPassengerCount()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM FlightPassengerView", connection);
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

        public DataTable FlightPassengerSuatAn()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM FlightPassengerSuatAnView", connection);
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

        public DataTable FlightPassengerHanhLy()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM FlightPassengerHanhLyView", connection);
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


        public DataTable FlightPassengerTotal()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM FlightPassengerTotalView", connection);
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

        public DataTable GetAllChuyenBaydt()
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
        public List<ChuyenBay> GetAllChuyenBay(ChuyenBay chuyenbay)
        {
            List<ChuyenBay> cbs = new List<ChuyenBay>();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM FindAllChuyenBay(@NgayBay, @DiemXuatPhat, @DiemDen)", connection);
                cmd.Parameters.AddWithValue("@NgayBay", chuyenbay.NgayBay);
                cmd.Parameters.AddWithValue("@DiemXuatPhat", chuyenbay.XuatPhat);
                cmd.Parameters.AddWithValue("@DiemDen", chuyenbay.Den);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maCB = reader["MaCB"].ToString().Trim();
                    string xuatphat = reader["DiemXuatPhat"].ToString().Trim();
                    string den = reader["DiemDen"].ToString().Trim();
                    string maMB = reader["MaMB"].ToString().Trim();

                    MayBay maybay = new MayBay(maMB, "0");

                    DateTime ngaybay = (DateTime)reader["NgayBay"];

                    TimeSpan catcanh = (TimeSpan)reader["GioCatCanh"];
                    TimeSpan hacanh = (TimeSpan)reader["GioHaCanh"];
                    int phutbay = (int)reader["PhutBay"];
                    ChuyenBay cb = new ChuyenBay(maCB, xuatphat, den, ngaybay, catcanh, hacanh, phutbay, maybay);
                    cbs.Add(cb);
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
            return cbs;
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
        //
        // MayBay
        //
        public DataTable GetAllMayBaydt()
        {
            DataTable table = new DataTable();
            try
            {
                KetNoi();

                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllMayBay()", connection);
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
        public void ThemMayBay(MayBay mb)
        {
            try
            {
                KetNoi();
                SqlCommand command = new SqlCommand($"AddNewMayBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TenMB", mb.TenMB);
                command.Parameters.AddWithValue("@soluongEco", mb.LoaiVe[0].SoLuong);
                command.Parameters.AddWithValue("@soluongDeluxe", mb.LoaiVe[1].SoLuong);
                command.Parameters.AddWithValue("@soluongskyBoss", mb.LoaiVe[2].SoLuong);
                command.Parameters.AddWithValue("@soluongBusiness", mb.LoaiVe[3].SoLuong);

                command.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"{error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }
        public void SuaMayBay(MayBay mb)
        {
            try
            {
                KetNoi();
                SqlCommand command = new SqlCommand($"UpdateMayBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MaMB", mb.MaMB);
                command.Parameters.AddWithValue("@TenMB", mb.TenMB);
                command.Parameters.AddWithValue("@soluongEco", mb.LoaiVe[0].SoLuong);
                command.Parameters.AddWithValue("@soluongDeluxe", mb.LoaiVe[1].SoLuong);
                command.Parameters.AddWithValue("@soluongskyBoss", mb.LoaiVe[2].SoLuong);
                command.Parameters.AddWithValue("@soluongBusiness", mb.LoaiVe[3].SoLuong);

                command.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"{error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }
        public void XoaMayBay(string maMB)
        {
            try
            {
                KetNoi();

                SqlCommand command = new SqlCommand($"DeleteMayBay", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MaMB", maMB);
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
        //
        // Suat An
        //
        public DataTable GetAllSuatAnDt()
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllSuatAn()", connection);
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
        public List<SuatAn> GetAllSuatAn()
        {
            List<SuatAn> sas = new List<SuatAn>(); 
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllSuatAn()", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maSA = reader["MaSA"].ToString();
                    string ten = reader["Ten"].ToString();
                    decimal gia = (decimal)reader["Gia"];
                    object img = reader["HinhMH"];
                    Image hinhMH;
                    SuatAn sa = new SuatAn();
                    if (img != DBNull.Value && img != null)
                    {
                        hinhMH = ByteArrayToImage((byte[])img);
                        sa = new SuatAn(maSA, ten, gia, hinhMH);
                    }
                    else sa = new SuatAn(maSA, ten, gia);
                    sas.Add(sa);
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
            return sas;
        }
        public void ThemSuatAn(SuatAn suatAn)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"AddNewSuatAn", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenSa", suatAn.TenSA);
                cmd.Parameters.AddWithValue("@Gia", suatAn.Gia);
                try
                {
                    cmd.Parameters.AddWithValue("@hinhMH", (object)ImageToByteArray(suatAn.HinhMH) ?? DBNull.Value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                cmd.ExecuteNonQuery();
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

        public void DatMonAn(GoiMon goimon)
        {
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("DatMonAn", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaSA", goimon.SA.MaSA);
                cmd.Parameters.AddWithValue("@MaVe", goimon.MaVe);
                cmd.Parameters.AddWithValue("@soluong", goimon.SoLuong);

                cmd.ExecuteNonQuery();
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

        public void SuaSuatAn(SuatAn suatAn)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"UpdateSuatAn", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSA", suatAn.MaSA);
                cmd.Parameters.AddWithValue("@TenSa", suatAn.TenSA);
                cmd.Parameters.AddWithValue("@Gia", suatAn.Gia);
                try
                {
                    cmd.Parameters.AddWithValue("@hinhMH", (object)ImageToByteArray(suatAn.HinhMH) ?? DBNull.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                cmd.ExecuteNonQuery();
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

        public void XoaSuatAn(string maSA)
        {
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"XoaSuatAn", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSA", maSA);
                cmd.ExecuteNonQuery();
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
        //
        // Hanh Ly
        //
        public DataTable GetAllHanhLyDt()
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllHanhLy()", connection);
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
        public List<HanhLy> GetAllHanhLy()
        {
            List<HanhLy> sas = new List<HanhLy>();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetAllHanhLy()", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maSA = reader["MaHL"].ToString();
                    int kg = (int)reader["KG"];
                    decimal gia = (decimal)reader["Gia"];
                    HanhLy hl = new HanhLy(maSA, kg, gia);
                    sas.Add(hl);
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
            return sas;
        }
        public void ThemHanhLy(HanhLy hl)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"AddNewHanhLy", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@soKG", hl.Cannang);
                cmd.Parameters.AddWithValue("@Gia", hl.Gia);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong!");
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"{error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                DongKetNoi();
            }
        }
        public void SuaHanhLy(HanhLy hl)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"UpdateHanhLy", connection);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@maHL", hl.MaHL);
                cmd.Parameters.AddWithValue("@soKG", hl.Cannang);
                cmd.Parameters.AddWithValue("@Gia", hl.Gia);
                cmd.ExecuteNonQuery();
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

        public void XoaHanhLy(object maHL)
        {
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"XoaHanhLy", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maHL", maHL);
                cmd.ExecuteNonQuery();
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

        //
        // Loai Ve
        //
        public LoaiVe GetLoaiVe(string maMB, string tenloai)
        {
            LoaiVe lv = new LoaiVe();
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM GetLoaiVe(@MaMB, @TenLoai)", connection);
                cmd.Parameters.AddWithValue("@MaMB", maMB);
                cmd.Parameters.AddWithValue("@TenLoai", tenloai);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maloai = reader["MaLoai"].ToString().Trim();
                    string ten = reader["TenLoai"].ToString().Trim();
                    decimal gia = (decimal)reader["Gia"];
                    int soluong = (int)reader["SoLuong"];
                    string mamb = reader["MaMB"].ToString().Trim();
                    lv = new LoaiVe(maloai, tenloai, gia, soluong, mamb);
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
            return lv;
        }

        public bool checkVe(LoaiVe lv, ChuyenBay cb)
        {
            object result;
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("SELECT dbo.CheckSoLuongLoaiVe(@MaLoai, @MaCB)", connection);

                cmd.Parameters.AddWithValue("@MaLoai", lv.MaLoai);
                cmd.Parameters.AddWithValue("@MaCB", cb.MaCB);
                result = cmd.ExecuteScalar();
                return (bool)result;
            }
            catch(SqlException ex)
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
            return false;
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
        public void ThemVeChuyenBay(VeMayBay ve)
        {
            string mave = string.Empty;
            GenerateMa(out mave);
            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("DatVe", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCB", ve.ChuyenBay.MaCB);
                cmd.Parameters.AddWithValue("@HoTen", ve.KhachHang.HoTen);
                cmd.Parameters.AddWithValue("@SDT", ve.KhachHang.SDT);
                cmd.Parameters.AddWithValue("@Email", ve.KhachHang.Email);
                cmd.Parameters.AddWithValue("@NgaySinh", ve.KhachHang.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", ve.KhachHang.GioiTinh);
                cmd.Parameters.AddWithValue("@MaLoai", ve.LoaiVe.MaLoai);
                if (ve.HanhLy.Gia != null)
                {
                    cmd.Parameters.AddWithValue("@MaHL", ve.HanhLy.MaHL);
                }
                else cmd.Parameters.AddWithValue("@MaHL", DBNull.Value);
                cmd.Parameters.AddWithValue("@TongTien", ve.Tongtien);
                cmd.Parameters.AddWithValue("@MaVe", mave);
                ve.AddMaVe(mave);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                DongKetNoi();
            }
        }

        public void ThemBienLai(string maVe, byte[] bienlai)
        {
            try
            {
                KetNoi();
                SqlCommand command = new SqlCommand("ThemBienLai", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Add parameters
                command.Parameters.AddWithValue("@BienLai", bienlai);
                command.Parameters.AddWithValue("@MaVe", maVe);
                // Execute the command
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                DongKetNoi();
            }
        }

        public byte[] GetBienLai(string maVe, string hoten)
        {
            byte[] bienlaiBytes = new byte[0];

            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand("SELECT dbo.TimVeChuyenBay(@MaVe, @HoTen)", connection); // Modified SQL query to use the scalar function
                cmd.Parameters.AddWithValue("@MaVe", maVe);
                cmd.Parameters.AddWithValue("@HoTen", hoten);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    bienlaiBytes = (byte[])result;
                }
                else MessageBox.Show("Khong tim thay ve hoac Ban chua thanh toan!!");
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
            return bienlaiBytes;
        }

    }
}
