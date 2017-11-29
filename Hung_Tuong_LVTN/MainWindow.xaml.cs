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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UCNVList a;
        public UCNV b ;
        public UCBatDongSan c;
        public MainWindow()
        {
            InitializeComponent();
            a = new UCNVList();
            usnv.Content = a;
            biNV.IsEnabled = false;
            nbiDetail.IsEnabled = true;
        }
        private void biNV_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            b = new UCNV();
            usnv.Content = b;

            biNV.IsEnabled = false;
            nbiList.IsEnabled = true;
            biKH.IsEnabled = true;
        }

        private void biKH_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            usnv.Content = null;
            biNV.IsEnabled = true;
            biKH.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = false;
        }

        private void nbiDetail_Click(object sender, System.EventArgs e)
        {
            
            b = new UCNV();
            usnv.Content = b;
            biNV.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = true;
        }

        private void nbiList_Click(object sender, System.EventArgs e)
        {
            UCNVList a = new UCNVList();
            usnv.Content = a;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = true;

        }


        private void biKH_ItemClick_2(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            UCKH uskh = new UCKH();
            usnv.Content = uskh;
            biNV.IsEnabled = true;
            biKH.IsEnabled = false;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            biBDS.IsEnabled = true;
        }
        private void biBDS_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            c = new UCBatDongSan();
            usnv.Content = c;
            biKH.IsEnabled = true;
            biNV.IsEnabled = true;
            biBDS.IsEnabled = false;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            doc.DockController.Hide(lpmenu);
        }
    }
}
