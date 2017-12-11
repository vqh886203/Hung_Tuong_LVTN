using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Hung_Tuong_LVTN.Page
{
    /// <summary>
    /// Interaction logic for BDSChiTiet.xaml
    /// </summary>
    public partial class BDSChiTiet
    {
        databaseDataContext data = new databaseDataContext();
        public BDSChiTiet()
        {
            InitializeComponent();
            ActiveListingIndex = 0;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ActiveListingIndex--;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ActiveListingIndex++;
        }
        public int ActiveListingIndex
        {
            get { return DanhSachBDS.ds.IndexOf((BatDongSanModel)LayoutRoot.DataContext); }
            set
            {
                value = Math.Min(Math.Max(0, value), DanhSachBDS.ds.Count - 1);
                if (ActiveListingIndex != value)
                    LayoutRoot.DataContext = DanhSachBDS.ds[value];
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DanhSachBDS.ds = list();
            ActiveListingIndex = 0;
        }
        public List<BatDongSanModel> list()
        {
            return data.BatDongSans.Select(x => new BatDongSanModel
            {
                bdsid = x.bdsid,
                dongia = String.Format("{0:.##}" + " triệu", x.dongia.Value/1000000),
                mota = x.mota,
                masoqsdd = x.masoqsdd,
                sonha = x.sonha,
                tenduong = x.tenduong,
                phuong = x.phuong,
                quan = x.quan,
                thanhpho = x.thanhpho,
                hoahong = String.Format("{0:.##}" + " %", x.hoahong.Value),
                tinhtrang = x.tinhtrang + "",
                sohuu = x.KhachHang.hoten,
                loai = x.LoaiBD.tenloai,
                hinhanh = x.hinhanh.ToString() == null ? null : x.hinhanh.ToArray(),
                dientich = String.Format("{0:.##}" + " m2", x.dientich.Value),
                chieurong = String.Format("{0:.##}" + " m", x.chieurong.Value),
                chieudai = String.Format("{0:.##}" + " m", x.chieudai.Value),
                tongtien = String.Format("{0:.##}" + " tỷ", (x.dientich.Value * x.dongia.Value) / 1000000000),
            }).ToList();
        }
    }
    public class ListingPositionToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listing = value as BatDongSanModel;
            return parameter.Equals("IsNotFirst") && DanhSachBDS.ds.IndexOf(listing) > 0 ||
                parameter.Equals("IsNotLast") && DanhSachBDS.ds.IndexOf(listing) < DanhSachBDS.ds.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BatDongSanModel
    {
        public int bdsid { get; set; }
        public string dongia { get; set; }
        public string dientich { get; set; }
        public string chieudai { get; set; }
        public string chieurong { get; set; }
        public string tongtien { get; set; }
        public string mota { get; set; }
        public string masoqsdd { get; set; }
        public string thanhpho { get; set; }
        public string tenduong { get; set; }
        public string sonha { get; set; }
        public string phuong { get; set; }
        public string quan { get; set; }
        public string hoahong { get; set; }
        public string tinhtrang { get; set; }
        public string sohuu { get; set; }
        public string loai { get; set; }
        public byte[] hinhanh { get; set; }
    }
    public static class DanhSachBDS
    {
        public static databaseDataContext dc = new databaseDataContext();
        public static List<BatDongSanModel> ds = dc.BatDongSans.Select(x => new BatDongSanModel
        {
            bdsid = x.bdsid,
            dongia = String.Format("{0:.##}" + " triệu", x.dongia.Value/1000000),
            mota = x.mota,
            masoqsdd = x.masoqsdd,
            sonha = x.sonha,
            tenduong = x.tenduong,
            phuong = x.phuong,
            quan = x.quan,
            thanhpho = x.thanhpho,
            hoahong = String.Format("{0:.##}" + "%", x.hoahong.Value),
            tinhtrang = x.tinhtrang + "",
            sohuu = x.KhachHang.hoten,
            loai = x.LoaiBD.tenloai,
            hinhanh = x.hinhanh.ToString() == null ? null : x.hinhanh.ToArray(),
            dientich = String.Format("{0:.##}" + " m2", x.dientich.Value),
            chieurong = String.Format("{0:.##}" + " m", x.chieurong.Value),
            chieudai = String.Format("{0:.##}" + " m", x.chieudai.Value),
            tongtien = String.Format("{0:.##}" + " tỷ", (x.dientich.Value * x.dongia.Value) / 1000000000),
        }).ToList();
    }
}