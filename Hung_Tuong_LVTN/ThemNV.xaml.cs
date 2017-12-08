using Hung_Tuong_LVTN.Model;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for ThemNV.xaml
    /// </summary>
    public partial class ThemNV : Window
    {
        databaseDataContext dc = new databaseDataContext();
        UCNVList ucl = new UCNVList();
        public ThemNV()
        {
            InitializeComponent();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kiemtra();
                NhanVien nv = new NhanVien();
                nv.taikhoan = txtTK.Text;
                nv.matkhau = "1";
                nv.tennv = txtTen.Text;
                nv.sdt = int.Parse(txtSDT.Text);
                nv.diachi = txtDiachi.Text;
                nv.ngaysinh = dtpNS.SelectedDate.Value;
                if (rdoNam.IsChecked == true)
                    nv.gioitinh = true;
                else
                    nv.gioitinh = false;
                nv.email = txtEmail.Text;
                nv.doanhthu = 0;
                nv.quyen = false;
                if (img.Source == null) nv.hinh = null;
                else
                nv.hinh = ConvertToBytes(img.Source as BitmapImage);
                dc.NhanViens.InsertOnSubmit(nv);
                dc.SubmitChanges();
                MainWindow main = new MainWindow();
                UCNV uc = new UCNV();
                main.usnv.Content = uc;
                ucl.grid.ItemsSource = new NhanVienModelView().DSNVList;
                uc.gridControl.ItemsSource = new NhanVienModelView().DSNV;
                this.Close();
            }
            catch
            {
                return;
            }

        }
        public byte[] ConvertToBytes(BitmapImage bitmapImage)
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
        private void txtEmail_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            txtTK.Text = txtEmail.Text;
        }

        private void kiemtra()
        {
            if(txtTen.Text==""  || txtEmail.Text == "" || txtSDT.Text == "" || txtDiachi.Text =="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !","Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dtpNS.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                dtpNS.Focus();
                return;
            }
            if (IsNumber(txtSDT.Text) != true || txtSDT.Text.Length <= 6 || txtSDT.Text.Length >11)
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại !","Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSDT.Focus();
                return;
            }
            if (img.Source == null)
            {
                
            }
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}
