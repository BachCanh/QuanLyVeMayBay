using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class HanhLy
    {
        private object maHL = null;
        private object cannang = null;
        private object gia = null;

        public HanhLy() 
        {
        }

        public HanhLy(object maHL, object cannang, object gia)
        {
            this.maHL = maHL;
            this.cannang = cannang;
            this.gia = gia;
        }
        public HanhLy(object cannang, object gia)
        {
            this.cannang = cannang;
            this.gia = gia;
        }
        public object MaHL 
        { get { return maHL; } }

        public object Cannang
        { get { return cannang; } }

        public object Gia
        { get { return gia; } }
    }
}
