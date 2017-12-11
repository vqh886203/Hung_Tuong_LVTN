using DevExpress.Xpf.Docking;
using Hung_Tuong_LVTN.Models;
using Hung_Tuong_LVTN.Page;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for UCHDKyGui.xaml
    /// </summary>
    public partial class UCHDKyGui : UserControl
    {
        databaseDataContext dc = new databaseDataContext();
        public UCHDKyGui()
        {
            InitializeComponent();
        }
        private void TableView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
            try
            {
                HDKGView row = (HDKGView)grid.SelectedItem;
                if (row == null) return;
                grid.RefreshData();

                foreach (HopDongKyGui i in dc.HopDongKyGuis.Where(x => x.kgid == row.kgid))
                {
                    if (i != null)
                    {
                        i.BatDongSan = dc.BatDongSans.Single(x => x.bdsid == row.bdsid);
                        i.NhanVien = dc.NhanViens.Single(x => x.nvid == row.nvid);
                        i.KhachHang = dc.KhachHangs.Single(x => x.khid == row.khid);
                        i.ngaybatdau = row.ngaybatdau.Date;
                        if (i.ngayketthuc <= row.ngaybatdau)
                        {
                            MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                            return;
                        }
                        i.ngayketthuc = row.ngayketthuc.Date;
                        i.chiphidv = row.chiphidv;
                        dc.SubmitChanges();
                        MessageBox.Show("Đã cập nhật thành công !");

                    }
                }
                grid.ItemsSource = new HDKGModelView().DSHDKG;
            }
            catch { return; }
        }

        private void biThem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            frmThemHDKyGui hopdong = new frmThemHDKyGui();
            hopdong.Show();
        }

        private void bicn_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var window = Application.Current.Windows.OfType<MainWindow>().SingleOrDefault(w => w.IsActive);
            window.usnv.Content = new UCHDKyGui();
            grid.ItemsSource = new HDKGModelView().DSHDKG;
        }

        private void bixoa_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có đồng ý xóa hợp đồng này ?", "Thông Báo", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    HDKGView a = grid.SelectedItem as HDKGView;
                    if (a == null)
                    {
                        MessageBox.Show("Không tồn tại hợp đồng!!");
                        return;
                    };
                    foreach (HopDongKyGui i in dc.HopDongKyGuis.Where(x => x.kgid == a.kgid))
                    {
                        if (i != null)
                        {
                            dc.HopDongKyGuis.DeleteOnSubmit(i);
                            dc.SubmitChanges();
                            MessageBox.Show("Xóa hợp đồng thành công !");
                            grid.ItemsSource = new HDKGModelView().DSHDKG;
                        }
                        else MessageBox.Show("Không thể xóa hợp đồng !!");
                    }
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        private void TableView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có đồng ý xóa hợp đồng này ?", "Thông Báo", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        HDKGView a = grid.SelectedItem as HDKGView;
                        if (a == null)
                        {
                            MessageBox.Show("Không tồn tại hợp đồng!!");
                            return;
                        };
                        foreach (HopDongKyGui i in dc.HopDongKyGuis.Where(x => x.kgid == a.kgid))
                        {
                            if (i != null)
                            {
                                dc.HopDongKyGuis.DeleteOnSubmit(i);
                                dc.SubmitChanges();
                                MessageBox.Show("Xóa hợp đồng thành công !");
                                grid.ItemsSource = new HDKGModelView().DSHDKG;
                            }
                            else MessageBox.Show("Không thể xóa hợp đồng !!");
                        }
                        break;
                    case MessageBoxResult.No:

                        break;

                }

            }

        }

        private void TableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //BDSView bds = grid.SelectedItem as BDSView;
            //var gridcontrol = dc.BatDongSans.Where(x => x.bdsid == bds.bdsid);
            //BDSChiTiet uc = new BDSChiTiet();
            //uc.ActiveListingIndex = bds.bdsid;
            var window = Application.Current.Windows.OfType<MainWindow>().SingleOrDefault(w => w.IsActive);
            DocumentPanel panel = new DocumentPanel();
            Frame fr = new Frame();
            fr.Content = new BDSChiTiet();
            panel.Caption = "Chi Tiết BĐS";
            panel.Content = fr;
            window.docGroup.Items.Add(panel);
        }
    }
}
