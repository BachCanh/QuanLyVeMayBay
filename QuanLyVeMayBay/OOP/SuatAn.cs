using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class SuatAn
    {
        private string maSA = string.Empty;
        private string tenSA = string.Empty;
        private int gia;

        public SuatAn() { }

        public SuatAn(string maSA, string ten, int gia)
        {
            this.maSA = maSA;
            this.tenSA = ten;
            this.gia = gia;
        }

        public string MaSA
        { get { return maSA; } }

        public string TenSA 
        { get { return tenSA; } }
        public int Gia
        { get { return gia; } }
    }
}
