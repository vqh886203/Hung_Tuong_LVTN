using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hung_Tuong_LVTN.Models
{
    class HDKGModelView
    {
        public IEnumerable<object> DSHDKG { get; set; }
        public IEnumerable<object> DSKhachHang { get; set; }
        public IEnumerable<object> DSBDS { get; set; }
        public IEnumerable<object> DSNV { get; set; }
        public databaseDataContext dc = new databaseDataContext();
        public HDKGModelView()
        {
            this.DSHDKG = getDSHDKGView();
            this.DSKhachHang = dc.KhachHangs.ToList();
            this.DSBDS = dc.BatDongSans.ToList();
            this.DSNV = dc.NhanViens.ToList();
        }
        public IEnumerable<object> getDSHDKGView()
        {

            return dc.HopDongKyGuis.Select(x => new HDKGView
            {
                kgid = x.kgid,
                bdsid = x.bdsid.Value,
                nvid = x.nvid.Value,
                khid = x.khid.Value,
                giatri = x.giatri.Value,
                chiphidv = x.chiphidv.Value,
                ngaybatdau = x.ngaybatdau.Value,
                ngayketthuc = x.ngayketthuc.Value,
            }).ToList();
        }

    }
    public class HDKGView
    {
        public int kgid { get; set; }
        public int bdsid { get; set; }
        public int nvid { get; set; }
        public int khid { get; set; }

        public double giatri { get; set; }
        public double chiphidv { get; set; }
        public DateTime ngaybatdau { get; set; }
        public DateTime ngayketthuc { get; set; }

    }
}
