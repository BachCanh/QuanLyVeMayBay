using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class GoiMon
    {
        string maVe = string.Empty, maSA = string.Empty;
        int soluong = 0;

        public GoiMon() { }

        public GoiMon(string maVe, string maSA, int soluong)
        {
            this.maVe = maVe;
            this.maSA = maSA;
            this.soluong = soluong;
        }

        public string MaVe
        { get { return this.maVe; } }
        
        public string MaSA
        { get { return this.maSA; } }

        public int SoLuong
        {  get { return this.soluong; } }
    }
}
