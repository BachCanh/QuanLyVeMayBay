using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeMayBay
{
    public class MayBay
    {
        string maMB = string.Empty, tenMB = string.Empty;
        List<LoaiVe> loaiVes = new List<LoaiVe>();

        public MayBay() { }

        public MayBay(string maMB, string tenMB)
        {
            this.maMB = maMB;
            this.tenMB = tenMB;
        }
        public MayBay(string tenMB, List<LoaiVe> loaiVes)
        {
            this.tenMB = tenMB;
            this.loaiVes = loaiVes;
        }

        public string MaMB
        {  get { return maMB; } }
        public string TenMB 
        { get {  return tenMB; } }
        public List<LoaiVe> LoaiVe
        {
            get { return loaiVes; }
        }

    }
}
