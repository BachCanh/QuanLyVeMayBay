using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class VeMayBay
    {
        private string maVe = string.Empty;
        private string tinhtrang = string.Empty;
        private DateTime ngaydat;
        private string bienlai = string.Empty;
        private double tongtien;
        private ConNguoi khachhang;
        private ChuyenBay chuyenbay;
        private LoaiVe loaive;
        private HanhLy hanhly;
    
        public VeMayBay() { }

        public VeMayBay(string maVe, string tinhtrang, DateTime ngaydat, string bienlai, double tongtien, ConNguoi khachhang, ChuyenBay chuyenbay, LoaiVe loaive)
        {
            this.maVe = maVe;
            this.tinhtrang = tinhtrang;
            this.ngaydat = ngaydat;
            this.bienlai = bienlai;
            this.tongtien = tongtien;
            this.khachhang = khachhang;
            this.chuyenbay = chuyenbay;
            this.loaive = loaive;
        }

        public VeMayBay(string maVe, string tinhtrang, DateTime ngaydat, string bienlai, double tongtien, ConNguoi khachhang, ChuyenBay chuyenbay, LoaiVe loaive, HanhLy hanhly)
        {
            this.maVe = maVe;
            this.tinhtrang = tinhtrang;
            this.ngaydat = ngaydat;
            this.bienlai = bienlai;
            this.tongtien = tongtien;
            this.khachhang = khachhang;
            this.chuyenbay = chuyenbay;
            this.loaive = loaive;
            this.hanhly = hanhly;
        }

        public string MaVe
        {
            get { return maVe; }
        }

        public string TinhTrang
        {
            get { return tinhtrang; }
        }

        public DateTime NgayDat
        {
            get { return ngaydat; }
        }

        public string BienLai
        {
            get { return bienlai; }
        }

        public double Tongtien
        { get { return tongtien; } }

        public ConNguoi KhachHang
        {
            get { return khachhang; }
        }

        public ChuyenBay ChuyenBay
        {
            get { return chuyenbay; }
        }

        public LoaiVe LoaiVe
        {
            get { return loaive; }
        }

        public HanhLy HanhLy
        {
            get { return hanhly; }
        }
    }
}
