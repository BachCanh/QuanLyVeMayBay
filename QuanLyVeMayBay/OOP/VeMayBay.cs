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
        private DateTime ngaydat;
        private byte[] bienlai = new byte[0];
        private decimal tongtien;
        private ConNguoi khachhang;
        private ChuyenBay chuyenbay;
        private LoaiVe loaive;
        private HanhLy hanhly;
        private List<GoiMon> goiMons = new List<GoiMon>();
        public VeMayBay() { }

        public VeMayBay(ConNguoi khachhang, ChuyenBay chuyenbay, LoaiVe loaive, HanhLy hanhly)
        {
            this.ngaydat = DateTime.Now;
            this.hanhly = hanhly;
            this.khachhang = khachhang;
            this.chuyenbay = chuyenbay;
            this.loaive = loaive;
            this.tongtien = CalTongTien();
        }

        public decimal CalTongTien()
        {
            decimal tt = 0;
            if(goiMons.Count > 0)
                foreach (GoiMon mon in goiMons)
                {
                    tt += mon.TongTien();
                }
            if (hanhly.Gia != null)
                tt += (decimal)hanhly.Gia;
            tt += loaive.Gia;
            return tt;
        }

        public VeMayBay(string maVe, DateTime ngaydat, byte[] bienlai, decimal tongtien, ConNguoi khachhang, ChuyenBay chuyenbay, LoaiVe loaive, HanhLy hanhly)
        {
            this.maVe = maVe;
            this.ngaydat = ngaydat;
            this.bienlai = bienlai;
            this.tongtien = tongtien;
            this.khachhang = khachhang;
            this.chuyenbay = chuyenbay;
            this.loaive = loaive;
            this.hanhly = hanhly;
        }
        public VeMayBay(string maVe, DateTime ngaydat, byte[] bienlai, decimal tongtien, ConNguoi khachhang, ChuyenBay chuyenbay, LoaiVe loaive, HanhLy hanhly, List<GoiMon> goiMons)
        {
            this.maVe = maVe;
            this.ngaydat = ngaydat;
            this.bienlai = bienlai;
            this.tongtien = tongtien;
            this.khachhang = khachhang;
            this.chuyenbay = chuyenbay;
            this.loaive = loaive;
            this.hanhly = hanhly;
            this.goiMons = goiMons;
        }

        public string MaVe
        {
            get { return maVe; }
        }

        public DateTime NgayDat
        {
            get { return ngaydat; }
        }

        public byte[] BienLai
        {
            get { return bienlai; }
        }

        public decimal Tongtien
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

        public List<GoiMon> GM
        {  get { return goiMons; } }

        public void ThemMon(GoiMon gm)
        {
            goiMons.Add(gm);
        }
        
        public void AddMaVe(string maVe)
        {
            this.maVe = maVe;
        }
        
    }
}
