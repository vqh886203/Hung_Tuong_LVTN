using DevExpress.Xpf.Core.Native;
using Hung_Tuong_LVTN.Model;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for UCNV.xaml
    /// </summary>
    public partial class UCNV : UserControl
    {
        databaseDataContext dc = new databaseDataContext();
        public int intidnv = 0;
        public UCNV()
        {
            InitializeComponent();
        }

        private void TableView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {

        }

        private void gridControl_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {

            NhanVienView nv = gridControl.SelectedItem as NhanVienView;

            if (nv == null) return;
            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == nv.nvid))
            {
                if (i != null)
                {

                    lbsdt.Content = i.sdt;
                    lbtennv.Content = i.tennv;
                    lbmail.Content = i.email;
                    lbtdiachi.Content = i.diachi;
                    lbdt.Content = i.doanhthu;
                    lbns.Content = i.ngaysinh;
                    if (i.hinh == null) { image.Source = null; }
                    else
                    {
                        Byte[] byteBLOBData = i.hinh.ToArray();
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        image.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                    }


                }
            }
        }

        private void gridControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == 1))
            {
                if (i != null)
                {

                    lbsdt.Content = i.sdt;
                    lbtennv.Content = i.tennv;
                    lbmail.Content = i.email;
                    lbtdiachi.Content = i.diachi;
                    lbdt.Content = i.doanhthu;
                    lbns.Content = i.ngaysinh;
                    if (i.hinh == null) { image.Source = null; }
                    else
                    {
                        Byte[] byteBLOBData = i.hinh.ToArray();
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        image.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                    }
                }
            }


        }

        public void xoa()
        {
            NhanVienView row = (NhanVienView)gridControl.SelectedItem;

            if (row == null) return;
            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == row.nvid))
            {
                if (i != null)
                {
                    dc.NhanViens.DeleteOnSubmit(i);
                    dc.SubmitChanges();
                }
            }
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NhanVienView a = gridControl.SelectedItem as NhanVienView;
                NVlistKH.stringnvid = a.nvid.ToString();
                NVlistKH frm = new NVlistKH();

                frm.Show();


            }
        }
    }
}
