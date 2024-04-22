
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class LoaiVe
    {
        private string maloai;
        private string tenloai;
        private int gia;
        private int soluong;
        private string maMB;

        public LoaiVe() { }

        public LoaiVe(int soluong)
        {
            this.soluong = soluong;
        }
        public LoaiVe(string maloai, string tenloai, int gia, int soluong, string maMB)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;
            this.gia = gia;
            this.soluong = soluong;
            this.maMB = maMB;
        }

        public string MaLoai
        {
            get { return maloai; }
        }

        public string TenLoai
        {
            get { return tenloai; }
        }

        public int Gia
        {
            get { return gia; }
        }

        public int SoLuong
        {
            get { return soluong; }
        }

        public string MaMB
        {
            get { return maMB; }
        }

    }
}
