using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hung_Tuong_LVTN.Model
{
    class KhachHangModelView
    {
        public databaseDataContext dc = new databaseDataContext();
        public IEnumerable<object> DSKH { get; set; }
        public IEnumerable<object> DSKHCN { get; set; }

        public KhachHangModelView()
        {
            this.DSKH = getdskhlist();
            //this.DSKHCN = getdskhcn();
        }
        public IEnumerable<object> getdskhlist()
        {
            return dc.KhachHangs.Select(x => new KhachHangList
            {
                khid = x.khid,
                hoten = x.hoten,
                diachi = x.diachi,
                diachitt = x.diachitt,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                email = x.email,
                sdt = x.sdt.Value,
                tuoi = DateTime.Now.Year - x.ngaysinh.Value.Year,
                cmnd = x.cmnd.Value,
                loaikh = x.loaikh.Value ? "Cần Mua" : "Cần Bán"

            }).ToList();
        }
        public List<KhachHangCaNhanView> getdskhcn(int a)
        {
            List<KhachHangCaNhanView> lst = new List<KhachHangCaNhanView>();
            foreach (KhachHang kh in dc.KhachHangs.Where(x => x.nvid == a))
            {
                KhachHangCaNhanView khcn = new KhachHangCaNhanView();
                khcn.khid = kh.khid;
                khcn.hoten = kh.hoten;
                khcn.sdt = kh.sdt.Value;
                khcn.gioitinh = kh.gioitinh.Value ? "Nam" : "Nữ";
                khcn.email = kh.email;
                khcn.loaikh = kh.loaikh.Value ? "Mua" : "Bán";
                khcn.diachi = kh.diachi;
                lst.Add(khcn);
            }
            return lst;
        }
        public KhachHang timkhachhang(int a)
        {
            foreach(KhachHang b in dc.KhachHangs.Where(x=>x.khid==a))
            {
                return b;
            }
            return null;    
        }
    }
    public class KhachHangView
    {
        public int nvid { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }

    }
    public class KhachHangCaNhanView
    {
        public int khid { get; set; }
        public string hoten { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string gioitinh { get; set; }
        public string email { get; set; }
        public string loaikh { get; set; }
    }
    public class KhachHangList
    {
        public int khid { get; set; }
        public string hoten { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string diachitt { get; set; }
        public int cmnd { get; set; }
        public string email { get; set; }
        public int tuoi { get; set; }
        public string gioitinh { get; set; }
        public string loaikh { get; set; }
    }
}
