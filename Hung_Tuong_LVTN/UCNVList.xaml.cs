using DevExpress.Xpf.Grid;
using Hung_Tuong_LVTN.Model;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for UCNVList.xaml
    /// </summary>
    public partial class UCNVList : UserControl
    {
        databaseDataContext dc = new databaseDataContext();
        public UCNVList()
        {
            InitializeComponent();
            cbo.Items.Add("Nam");
            cbo.Items.Add("Nữ");
            grid.ItemsSource = new NhanVienModelView().DSNVList;
        }
        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void tableView_RowUpdated(object sender, RowEventArgs e)
        {
            try
            {
                NhanVienViewList row = (NhanVienViewList)grid.SelectedItem;
                if (row == null) return;
                grid.RefreshData();

                foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == row.nvid))
                {
                    if (i != null)
                    {
                        i.tennv = row.tennv;
                        if (row.gioitinh == "Nam")
                            i.gioitinh = true;
                        else i.gioitinh = false;
                        i.hinh = ConvertToBytes(ToImage(row.hinh.ToArray()));
                        i.diachi = row.diachi;
                        i.doanhthu = row.doanhthu;
                        i.ngaysinh = row.ngaysinh;
                        i.matkhau = row.matkhau;
                        i.email = row.email;
                        i.sdt = row.sdt;
                        i.quyen = row.quyen;
                        dc.SubmitChanges();
                        MessageBox.Show("Đã cập nhật thành công !");
                    }
                }
                grid.ItemsSource = new NhanVienModelView().DSNVList;
            }
            catch { return; }
        }
        public static byte[] ConvertToBytes(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        public void xoaNV()
        {



        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có đồng ý xóa nhân viên này ?", "Thông Báo", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NhanVienViewList a = grid.SelectedItem as NhanVienViewList;
                        if (a == null)
                        {
                            MessageBox.Show("Không tồn tại nhân viên !!");
                            return;
                        };
                        foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == a.nvid))
                        {
                            if (i != null)
                            {
                                dc.NhanViens.DeleteOnSubmit(i);
                                dc.SubmitChanges();
                                MessageBox.Show("Xóa nhân viên thành công !");
                                grid.ItemsSource = new NhanVienModelView().DSNVList;
                            }
                            else MessageBox.Show("Không tồn tại nhân viên !!");
                        }
                        break;
                    case MessageBoxResult.No:

                        break;

                }

            }
        }

        private void bicn_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            grid.ItemsSource = new NhanVienModelView().DSNVList;
        }

        private void biThem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ThemNV a = new ThemNV();
            a.Show();
        }

        private void bixoa_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có đồng ý xóa nhân viên này ?", "Thông Báo", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    NhanVienViewList a = grid.SelectedItem as NhanVienViewList;
                    if (a == null)
                    {
                        MessageBox.Show("Không tồn tại nhân viên !!");
                        return;
                    };
                    foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == a.nvid))
                    {
                        if (i != null)
                        {
                            dc.NhanViens.DeleteOnSubmit(i);
                            dc.SubmitChanges();
                            MessageBox.Show("Xóa nhân viên thành công !");
                            grid.ItemsSource = new NhanVienModelView().DSNVList;
                        }
                        else MessageBox.Show("Không tồn tại nhân viên !!");
                    }
                    break;
                case MessageBoxResult.No:

                    break;

            }
        }
    }
}
