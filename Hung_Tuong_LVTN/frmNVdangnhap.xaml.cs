using DevExpress.Xpf.Core.Native;
using Hung_Tuong_LVTN.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for frmNVdangnhap.xaml
    /// </summary>
    public partial class frmNVdangnhap : Window
    {
        public static string stringnvid = string.Empty;
        private NhanVien nv = new NhanVien();
        private databaseDataContext dc = new databaseDataContext();
        private KhachHangModelView nvmd = new KhachHangModelView();
        private List<KhachHangCaNhanView> khcn = new List<KhachHangCaNhanView>();
        public frmNVdangnhap()
        {
            InitializeComponent();
            cbx.ItemsSource = dc.NhanViens.ToList();
            timnv();
            Title = nv.tennv;
            lbname.Content = nv.tennv;
            lbngaysinh.Content = nv.ngaysinh.ToString();
            lbGioiTinh.Content = nv.gioitinh.Value ? "Nam" : "Nữ";
            lbsdt.Content = nv.sdt.ToString();
            lbemail.Content = nv.email;
            lbdoanhthu.Content = nv.doanhthu.ToString();
            if (nv.hinh == null) { img.Source = null; }
            else
            {
                Byte[] byteBLOBData = nv.hinh.ToArray();
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                img.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
            }
            khcn = nvmd.getdskhcn(nv.nvid);
            gridControlkh.ItemsSource = khcn;
        }

        private void bicn_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            frmThemKH.manvkh = nv.nvid.ToString();
            frmThemKH frm = new frmThemKH();

            frm.Show();
            this.Close();
        }
        private void timnv()
        {

            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == int.Parse(stringnvid)))
            {
                nv = i;
            }
        }

        private void bicn_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
            KhachHangCaNhanView kh = (KhachHangCaNhanView)gridControlkh.SelectedItem;
            KhachHang k = new KhachHang();
            foreach(KhachHang n in dc.KhachHangs.Where(x=>x.khid==kh.khid))
            {
                k = n;
            }
            string str = "Bạn có đồng ý chuyển Khách Hàng [" + k.hoten + "] cho Nhân Viên [" + cbx.Text + "] không ?";
            MessageBoxResult result = MessageBox.Show(str, "Thông Báo", MessageBoxButton.YesNo);
            if(result== MessageBoxResult.Yes)
            {
                k.NhanVien = dc.NhanViens.Single(x => x.nvid == int.Parse(cbx.SelectedValue.ToString()));
                dc.SubmitChanges();
                
            }
            else return;
            List<KhachHangCaNhanView> khcn = new List<KhachHangCaNhanView>();
            khcn = nvmd.getdskhcn(nv.nvid);
            gridControlkh.ItemsSource = khcn;
        }
    }
}
