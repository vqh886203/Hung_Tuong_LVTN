using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for frmThemKH.xaml
    /// </summary>
    
    public partial class frmThemKH : Window
    {
        public static string manvkh = string.Empty;
        databaseDataContext dc = new databaseDataContext();
        public frmThemKH()
        {
            InitializeComponent();
            cbx.Items.Add("Nam");
            cbx.Items.Add("Nữ");
        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            frmNVdangnhap.stringnvid = manvkh;
            frmNVdangnhap frm = new frmNVdangnhap();

            frm.Show();
            this.Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kiemtra();
                KhachHang kh = new KhachHang();
                kh.hoten = txtname.Text;
                kh.diachi = txtdiachi.Text;
                kh.diachitt = txtdiachitt.Text;
                kh.cmnd = int.Parse(txtcmnd.Text);
                kh.ngaysinh = dtpNS.SelectedDate;
                kh.sdt = int.Parse(txtsdt.Text);
                if (cbx.Text == "Nam") kh.gioitinh = true;
                else kh.gioitinh = false;
                kh.email = txtemail.Text;
                if (rdo1.IsChecked == true) kh.loaikh = true;
                else kh.loaikh = false;
                kh.mota = "";
                kh.nvid = int.Parse(manvkh);
                dc.KhachHangs.InsertOnSubmit(kh);
                dc.SubmitChanges();
                frmNVdangnhap.stringnvid = manvkh;
                frmNVdangnhap frm = new frmNVdangnhap();

                frm.Show();
                this.Close();
            }
            catch { return; }
        }
        private void kiemtra()
        {
            if (txtname.Text == "" || cbx.Text == "" || txtcmnd.Text == "" || txtemail.Text == "" || txtdiachi.Text == "" || txtdiachitt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dtpNS.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng chọn [Ngày Sinh] !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                dtpNS.Focus();
                return;
            }
            if (IsNumber(txtsdt.Text) != true || txtsdt.Text.Length <= 6 || txtsdt.Text.Length > 11)
            {
                MessageBox.Show("Vui lòng nhập đúng [Số Điện Thoại] !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsdt.Focus();
                return;
            }
            if (IsNumber(txtcmnd.Text) != true ||txtsdt.Text.Length !=9)
            {
                MessageBox.Show("Vui lòng nhập đúng [CMND] !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtcmnd.Focus();
                return;
            }


        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}
