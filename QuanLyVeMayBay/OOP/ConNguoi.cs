using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyVeMayBay
{
    public class ConNguoi
    {
        private string hoten;
        private DateTime ngaysinh;
        private string gioitinh;
        private string sdt;
        private string email;

        public ConNguoi() { }   

        public ConNguoi(string hoten, DateTime ngaysinh, string gioitinh, string sdt, string email)
        {
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.email = email;
        }

        public string HoTen
        {
            get { return hoten; }
        }

        public DateTime NgaySinh
        {
            get { return ngaysinh; }
        }

        public string GioiTinh
        {
            get { return gioitinh; }
        }

        public string SDT
        {
            get { return sdt; }
        }

        public string Email
        {
            get { return email; }
        }
    }
}
