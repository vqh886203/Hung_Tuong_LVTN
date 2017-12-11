using Hung_Tuong_LVTN.Model;
using Hung_Tuong_LVTN.Models;
using Hung_Tuong_LVTN.RP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for frmThemHDDC.xaml
    /// </summary>
    public partial class frmThemHDDC : Window
    {
        public static string stringkhid = string.Empty;
        public static string stringbdsid = string.Empty;
        private databaseDataContext dc = new databaseDataContext();
        private KhachHangModelView khmd = new KhachHangModelView();
        private BDSModelView bdsview = new BDSModelView();
        private List<CrpHDDC> lst = new List<CrpHDDC>();
        public frmThemHDDC()
        {
            InitializeComponent();
            if (stringkhid != "")
            {
                KhachHang a = khmd.timkhachhang(int.Parse(stringkhid));
                //khách hàng mua:
                lbtennm.Content = a.hoten;
                lbsmndnm.Content = a.cmnd;
                lbdiachinm.Content = a.diachitt;
                lbdienthoainm.Content = a.sdt;
            }
            if (stringbdsid != "")
            {
                BatDongSan bds = bdsview.timbds(int.Parse(stringbdsid));
                //Bất động sản:
                lbmsch.Content = bds.masoqsdd;
                lbchieudai.Content = bds.chieudai;
                lbchieurong.Content = bds.chieurong;
                lbdientich.Content = bds.dientich;

                lbtonggiatri.Content = bds.dientich * bds.dongia + ".000.000  VNĐ";
                //khách hàng bán:
                lbtennb.Content = bds.KhachHang.hoten;
                lbcmndnb.Content = bds.KhachHang.cmnd;
                lbdiachinb.Content = bds.KhachHang.diachitt;
                lbsdtnb.Content = bds.KhachHang.sdt;
                lbtiencoc.Content = bds.dientich * bds.dongia * 10 / 100 + ".000.000  VNĐ";
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DSKHMUA a = new DSKHMUA();
            a.Show();
            this.Close();
        }

        private void Image_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            DSBDSMUA a = new DSBDSMUA();
            a.Show();
            this.Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try { 
                HDDatCoc hd = new HDDatCoc();
                hd.khid = int.Parse(stringkhid);
                hd.bdsid = int.Parse(stringbdsid);
                hd.ngaylaphd = DateTime.Now;
                hd.tinhtrang = 1;
                hd.ngayhethan = dtpNS.SelectedDate;
                foreach(BatDongSan bds in dc.BatDongSans.Where(x=>x.bdsid==hd.bdsid))
                {
                    bds.tinhtrang = 2;
                    dc.SubmitChanges();
                }
                dc.HDDatCocs.InsertOnSubmit(hd);
                dc.SubmitChanges();

                MessageBox.Show("Lập Hợp Đồng Thành Công !", "Thông Báo");
                lst.Clear();
                lst.Add(getRPhddc(hd));
                WindowRPhddc r = new WindowRPhddc();
                r.data = getRP(lst);
                r.Show();

            }
            catch { return;}
        }

        private CrpHDDC getRPhddc(HDDatCoc a)
        {
            CrpHDDC crp = new CrpHDDC();
            crp.ngaylaphd = a.ngaylaphd.Value.ToShortDateString();

            crp.tennm = a.KhachHang.hoten;
            crp.cmndnm = a.KhachHang.cmnd.Value;
            crp.hokhaunm = a.KhachHang.diachitt;
            crp.diachinm = a.KhachHang.diachi;
            crp.sdtnm = a.KhachHang.sdt.Value;

            crp.tennb = a.BatDongSan.KhachHang.hoten;
            crp.cmndnb = a.BatDongSan.KhachHang.cmnd.Value;
            crp.hokhaunb = a.BatDongSan.KhachHang.diachitt;
            crp.diachinb = a.BatDongSan.KhachHang.diachi;
            crp.sdtnb = a.BatDongSan.KhachHang.sdt.Value;

            crp.msch = a.BatDongSan.masoqsdd;
            crp.chieurong = a.BatDongSan.chieurong.Value;
            crp.chieudai = a.BatDongSan.chieudai.Value;
            crp.dt = a.BatDongSan.dientich.Value;
            crp.tonggiatri = a.BatDongSan.dongia.Value * a.BatDongSan.dientich.Value;
            crp.tiencoc = a.BatDongSan.dongia.Value * a.BatDongSan.dientich.Value * 10 / 100;
            crp.ngayhethan = a.ngayhethan.Value.ToShortDateString();
            return crp;
        }

        private IEnumerable<object> getRP(List<CrpHDDC> ds)
        {
            return ds.Select(x => new
            {
                ngaylaphd = x.ngaylaphd,

                tennm = x.tennm,
                cmndnm = x.cmndnm,
                hokhaunm = x.hokhaunm,
                diachinm = x.diachinm,
                sdtnm = x.sdtnm ,

                tennb = x.tennb ,
                cmndnb = x.cmndnb ,
                hokhaunb =  x.hokhaunb ,
                diachinb = x.diachinb ,
                sdtnb = x.sdtnb ,

                msch = x.msch,
                chieurong = x.chieurong,
                chieudai = x.chieudai,
                dt =   x.dt,
                tonggiatri = x.tonggiatri,
                tiencoc =  x.tiencoc,
                ngayhethan =  x.ngayhethan,
        }).ToList();
        }
    }
}
