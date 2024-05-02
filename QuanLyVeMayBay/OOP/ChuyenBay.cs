using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class ChuyenBay
    {
        private string maCB = string.Empty;
        private string xuatphat = string.Empty;
        private string den = string.Empty;
        private DateTime ngaybay;
        private TimeSpan hacanh, catcanh;
        private int phutbay;
        private MayBay maybay;
        public ChuyenBay() { }

        public ChuyenBay(string xuatphat, string den, DateTime ngaybay)
        {
            this.xuatphat = xuatphat;
            this.den = den;
            this.ngaybay = ngaybay;
        }

        public ChuyenBay(string maCB, string xuatphat, string den, DateTime ngaybay, TimeSpan catcanh, TimeSpan hacanh, int phutbay, MayBay maybay)
        {
            this.xuatphat = xuatphat;
            this.den = den;
            this.ngaybay = ngaybay;
            this.maCB = maCB;
            this.hacanh = hacanh;
            this.catcanh = catcanh;
            this.phutbay = phutbay;
            this.maybay = maybay;
        }
        public ChuyenBay(string xuatphat, string den, DateTime ngaybay, TimeSpan catcanh, TimeSpan hacanh, int phutbay, MayBay maybay)
        {
            this.xuatphat = xuatphat;
            this.den = den;
            this.ngaybay = ngaybay;
            maCB = string.Empty;
            this.hacanh = hacanh;
            this.catcanh = catcanh;
            this.phutbay = phutbay;
            this.maybay = maybay;
        }


        public string XuatPhat
        {
            get { return xuatphat; }
        }
        public string Den
        {
            get { return den; }
        }

        public string MaCB
        { get { return maCB; } }

        public MayBay MB
        { get { return maybay; } }

        public DateTime NgayBay
        { get { return ngaybay; } }

        public TimeSpan HaCanh
        { get { return hacanh; } }
        public TimeSpan CatCanh
        { get { return catcanh; } }
        public int PhutBay
        {  get { return phutbay; } }
    }
}
