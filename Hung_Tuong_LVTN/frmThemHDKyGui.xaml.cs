using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for frmThemHDKyGui.xaml
    /// </summary>
    public partial class frmThemHDKyGui : Window
    {
        databaseDataContext dc = new databaseDataContext();
        int nvid = 1;
        public frmThemHDKyGui()
        {
            InitializeComponent();
            reload();
        }
        private void btnThemKH_Click(object sender, RoutedEventArgs e)
        {

            frmThemKH frmthem = new frmThemKH();
            frmThemKH.manvkh = "1";
            frmthem.Show();

        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            HopDongKyGui hdkg = new HopDongKyGui();
            BatDongSan bds = new BatDongSan();
            
            bds.KhachHang = dc.KhachHangs.Single(x => x.khid == int.Parse(cboKH.SelectedValue.ToString()));
            bds.LoaiBD = dc.LoaiBDs.Single(x => x.loaiid == int.Parse(cboLoai.SelectedValue.ToString()));
            bds.chieudai = double.Parse(txtDai.Text);
            bds.chieurong = double.Parse(txtRong.Text);
            bds.dientich = double.Parse(txtDai.Text) * double.Parse(txtRong.Text);
            bds.dongia = double.Parse(txtDongia.Text);
            bds.hoahong = double.Parse(txtHH.Text);
            bds.sonha = txtSonha.Text;
            bds.tenduong = txtDuong.Text;
            bds.phuong = txtPhuong.Text;
            bds.quan = txtQuan.Text;
            bds.thanhpho = txtTP.Text;
            bds.mota = txtMota.Text;
            bds.hinhanh = null;
            bds.tinhtrang = 1;//
            bds.masoqsdd = txtQSDD.Text;

            MessageBoxResult result = MessageBox.Show("Bạn có đồng ý lập hợp đồng này ?", "Thông Báo", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    dc.BatDongSans.InsertOnSubmit(bds);
                    dc.SubmitChanges();
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.BatDongSans);
                    int idbds = dc.BatDongSans.Max(x => x.bdsid);
                    hdkg.BatDongSan = dc.BatDongSans.Single(x => x.bdsid == idbds);
                    hdkg.NhanVien = dc.NhanViens.Single(x => x.nvid == nvid);//idnv
                    hdkg.KhachHang = dc.KhachHangs.Single(x => x.khid == int.Parse(cboKH.SelectedValue.ToString()));
                    hdkg.ngaybatdau = dpbatdau.DateTime;
                    hdkg.ngayketthuc = dpketthuc.DateTime;
                    hdkg.chiphidv = double.Parse(txtChiPhi.Text);
                    hdkg.giatri = double.Parse(txtTongGia.Text);
                    dc.HopDongKyGuis.InsertOnSubmit(hdkg);
                    dc.SubmitChanges();
                    MessageBox.Show("Lập Hợp Đồng thành công!");
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;

            }
        }

        private void txtRong_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtRong.Text == "") return;
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                txtChuVi.Text = ((double.Parse(txtDai.Text) + double.Parse(txtRong.Text) * 2)).ToString();
                txtDienTich.Text = (double.Parse(txtDai.Text) * double.Parse(txtRong.Text)).ToString();
            }
        }



        private void txtDongia_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDongia.Text == "") return;
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                txtTongGia.Text = (double.Parse(txtDongia.Text) * double.Parse(txtDienTich.Text)).ToString();
            }
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }


        public void reload()
        {
            cboKH.ItemsSource = dc.KhachHangs.ToList();
            cboKH.DisplayMemberPath = "hoten";
            cboKH.SelectedValuePath = "khid";
            cboLoai.ItemsSource = dc.LoaiBDs.ToList();
            cboLoai.DisplayMemberPath = "tenloai";
            cboLoai.SelectedValuePath = "loaiid";
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            var window = Application.Current.Windows.OfType<MainWindow>().SingleOrDefault(w => w.IsActive);
            window.usnv.Content = new UCHDKyGui();
        }
    }
}
