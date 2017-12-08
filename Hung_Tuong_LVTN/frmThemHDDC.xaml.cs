using Hung_Tuong_LVTN.Model;
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
        private KhachHangModelView khmd = new KhachHangModelView();
        private BDSModelView bdsview = new BDSModelView();
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
    }
}
