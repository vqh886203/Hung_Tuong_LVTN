using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hung_Tuong_LVTN.Model
{
    class BDSModelView
    {
        public IEnumerable<object> DSBDS { get; set; }

        public databaseDataContext dc = new databaseDataContext();
        public BDSModelView()
        {
            this.DSBDS = getDSBDSView();
        }
        public IEnumerable<object> getDSBDSView()
        {

            return dc.BatDongSans.Select(x => new BDSView
            {
                bdsid = x.bdsid,
                dongia = String.Format("{0:.##}" + " triệu", x.dongia.Value/1000000),
                diachi = x.sonha + ", " + x.tenduong + "\n" 
                + "P. " + x.phuong
                + ", Q. " + x.quan + ", TP. " + x.thanhpho,
                dientich = String.Format("{0:.##}" + " m2", x.dientich.Value),
                chieurong = String.Format("{0:.##}" + " m", x.chieurong.Value),
                chieudai = String.Format("{0:.##}" + " m", x.chieudai.Value),
                tongtien = String.Format("{0:.##}" + " tỷ", (x.dientich.Value * x.dongia.Value)/1000000000),
                hinhanh = x.hinhanh.ToString() == null ? null : x.hinhanh.ToArray(),
                tenkh = x.KhachHang.hoten,
                tenloai = x.LoaiBD.tenloai

            }).ToList();
        }
        public List<BatDongSan> getbds()
        {
            List<BatDongSan> lst = new List<BatDongSan>();
            foreach (BatDongSan kh in dc.BatDongSans.Where(x => x.tinhtrang == 1))
            {
                lst.Add(kh);
            }
            return lst;
        }

        public BatDongSan timbds(int a)
        {
            foreach (BatDongSan b in dc.BatDongSans.Where(x => x.bdsid == a))
            {
                return b;
            }
            return null;
        }

    }

    public class BDSView
    {
        public int bdsid { get; set; }
        public byte[] hinhanh { get; set; }
        public string dientich { get; set; }
        public string chieudai { get; set; }
        public string chieurong { get; set; }
        public string diachi { get; set; }
        public string dongia { get; set; }
        public string tenkh { get; set; }
        public string tenloai { get; set; }
        public string tongtien { get; set; }
    }
}
