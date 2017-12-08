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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        databaseDataContext dc = new databaseDataContext();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtid.Text=="admin" && txtpass.Password.ToString()=="admin")
            {
                MainWindow wd = new MainWindow();
                wd.Show();
                this.Close();
            }
            else if(txtid.Text != "admin")
            { 
                string a = txtid.Text;
                NhanVien nv = new NhanVien();
                foreach(NhanVien n in dc.NhanViens.Where(x=>x.taikhoan == a))
                {
                    nv = n;
                }
                if (txtpass.Password.ToString() == nv.matkhau)
                {
                    frmNVdangnhap.stringnvid = nv.nvid.ToString();
                    frmNVdangnhap frm = new frmNVdangnhap();

                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài Khoản Hoặc Mặt Khẩu Không Đúng !");
                }
            }
        }

      

        private void txtid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtid.Text = "";
           
        }

        private void txtpass_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtpass.Text = "";
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if (txtid.Text == "admin" && txtpass.Password.ToString() == "admin")
                {
                    MainWindow wd = new MainWindow();
                    wd.Show();
                    this.Close();
                }
                else if (txtid.Text != "admin")
                {
                    string a = txtid.Text;
                    NhanVien nv = new NhanVien();
                    foreach (NhanVien n in dc.NhanViens.Where(x => x.taikhoan == a))
                    {
                        nv = n;
                    }
                    if (txtpass.Password.ToString() == nv.matkhau)
                    {
                        frmNVdangnhap.stringnvid = nv.nvid.ToString();
                        frmNVdangnhap frm = new frmNVdangnhap();

                        frm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản Hoặc Mặt Khẩu Không Đúng !");
                    }
                }
            }
        }
    }
}
