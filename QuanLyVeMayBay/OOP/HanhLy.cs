using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class HanhLy
    {
        private string maHL = string.Empty;
        private int cannang = 0;
        private int gia = 0;

        public HanhLy() { }

        public HanhLy(string maHL, int cannang, int gia)
        {
            this.maHL = maHL;
            this.cannang = cannang;
            this.gia = gia;
        }
        public string MaHL 
        { get { return maHL; } }

        public int Cannang
        { get { return cannang; } }

        public int Gia
        { get { return gia; } }
    }
}
