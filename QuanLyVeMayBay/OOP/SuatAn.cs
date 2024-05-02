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
        private decimal gia;
        private Image hinhMH;

        public SuatAn() { }

        public SuatAn(string maSA, string ten, decimal gia, Image hinhMH)
        {
            this.maSA = maSA;
            this.tenSA = ten;
            this.gia = gia;
            this.hinhMH = hinhMH;
        }
        public SuatAn(string maSA, string ten, decimal gia)
        {
            this.maSA = maSA;
            this.tenSA = ten;
            this.gia = gia;
        }
        public SuatAn(string ten, decimal gia, Image hinhMH)
        {
            this.tenSA = ten;
            this.gia = gia;
            this.hinhMH = hinhMH;
        }

        public string MaSA
        { get { return maSA; } }

        public string TenSA 
        { get { return tenSA; } }
        public decimal Gia
        { get { return gia; } }
        public Image HinhMH
        { get { return hinhMH; } }
    }
}
