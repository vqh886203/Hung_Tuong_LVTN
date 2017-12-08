using DevExpress.Xpf.Core.Native;
using Microsoft.Win32;
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
    /// Interaction logic for SuaBDS.xaml
    /// </summary>
    public partial class SuaBDS : Window
    {
        public int msBDS;
        databaseDataContext dc = new databaseDataContext();
        public SuaBDS()
        {
            InitializeComponent();
            cboTt.Items.Add("Chưa Bán");
            cboTt.Items.Add("Mở Bán");
            cboTt.Items.Add("Hết Hạn");
            cboTt.Items.Add("Đã Bán");
            cboKh.ItemsSource = dc.KhachHangs.ToList();
            cboKh.DisplayMemberPath = "hoten";
            cboKh.SelectedValuePath = "khid";
            cboLoai.ItemsSource = dc.LoaiBDs.ToList();
            cboLoai.DisplayMemberPath = "tenloai";
            cboLoai.SelectedValuePath = "loaiid";
        }
        public void setBDS(int ms)
        {
            msBDS = ms;
            foreach (BatDongSan a in dc.BatDongSans.Where(x => x.bdsid == ms))
            {
                if (a != null)
                {
                    txtMsqsdd.Text = a.masoqsdd;
                    txtHh.Text = a.hoahong.ToString();
                    txtSonha.Text = a.sonha;
                    txtDuong.Text = a.tenduong;
                    txtQuan.Text = a.quan;
                    txtPhuong.Text = a.phuong;
                    txtTP.Text = a.thanhpho;
                    txtDai.Text = a.chieudai.ToString();
                    txtRong.Text = a.chieurong.ToString();
                    txtDongia.Text = a.dongia.ToString();
                    txtMota.Text = a.mota;
                    cboKh.Text = a.KhachHang.hoten;
                    cboLoai.Text = a.LoaiBD.tenloai;
                    if (a.hinhanh == null || a.hinhanh.Length <= 5) { img.Source = null; }
                    else
                    {
                        Byte[] byteBLOBData = a.hinhanh.ToArray();
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        img.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                    }

                   
                    cboTt.Text = cboTt.Items[a.tinhtrang.Value].ToString();


                }
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

            foreach (BatDongSan bds in dc.BatDongSans.Where(x => x.bdsid == msBDS))
            {
                if (bds != null)
                {
                    bds.chieudai = double.Parse(txtDai.Text);
                    bds.chieurong = double.Parse(txtRong.Text);
                    bds.dientich = double.Parse(txtDai.Text) * double.Parse(txtRong.Text);
                    bds.dongia = double.Parse(txtDongia.Text);
                    bds.hoahong = double.Parse(txtHh.Text);
                    bds.KhachHang = dc.KhachHangs.Single(x => x.khid == int.Parse(cboKh.SelectedValue.ToString()));
                    bds.LoaiBD = dc.LoaiBDs.Single(x => x.loaiid == int.Parse(cboLoai.SelectedValue.ToString()));
                    bds.tinhtrang = cboTt.SelectedIndex;
                    bds.masoqsdd = txtMsqsdd.Text;
                    bds.sonha = txtSonha.Text;
                    bds.tenduong = txtDuong.Text;
                    bds.phuong = txtPhuong.Text;
                    bds.quan = txtQuan.Text;
                    bds.thanhpho = txtTP.Text;
                    bds.mota = txtMota.Text;
                    bds.hinhanh = img.Source == null ? null : ConvertToBytes(img.Source as BitmapImage);
                    dc.SubmitChanges();
                    MessageBox.Show("Sửa BĐS thành công !!!");
                }

            }

            this.Close();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        private void btnThemHinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            open.Multiselect = true;
            if (open.ShowDialog() == true)
            {
                List<byte[]> dsHinh = new List<byte[]>();
                string[] strArray = open.FileNames;
                for (int i = 0; i < strArray.Length; i++)
                {
                    FileStream fs = new FileStream(strArray[i], FileMode.Open, FileAccess.Read);
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    dsHinh.Add(data);
                }
                for (int j = 0; j < dsHinh.Count; j++)
                {
                    HinhBD h = new HinhBD();
                    h.bdsid = msBDS;
                    h.hinh = dsHinh[j];
                    dc.HinhBDs.InsertOnSubmit(h);
                    dc.SubmitChanges();
                }
            }
        }
    }
}
