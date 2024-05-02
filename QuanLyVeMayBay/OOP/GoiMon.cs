using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class GoiMon
    {
        private string maVe = string.Empty;
        private SuatAn sa;
        private int soluong = 0;

        public GoiMon() { }
        public GoiMon(SuatAn sa, int soluong)
        {
            this.sa = sa;
            this.soluong = soluong;
        }

        public GoiMon(string maVe, SuatAn sa, int soluong)
        {
            this.maVe = maVe;
            this.sa = sa;
            this.soluong = soluong;
        }

        public decimal TongTien()
        {
            return sa.Gia * soluong;
        }

        public void SetMaVe(string mave)
        {
            this.maVe = mave;
        }

        public string MaVe
        { get { return this.maVe; } }
        
        public SuatAn SA
        { get { return this.sa; } }

        public int SoLuong
        {  get { return this.soluong; } }
    }
}
