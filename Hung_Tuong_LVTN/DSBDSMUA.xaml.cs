using Hung_Tuong_LVTN.Model;
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
    /// Interaction logic for DSBDSMUA.xaml
    /// </summary>
    public partial class DSBDSMUA : Window
    {
        private BDSModelView bds = new BDSModelView();
        public DSBDSMUA()
        {
            InitializeComponent();
            List<BatDongSan> lst = bds.getbds();
            grid.ItemsSource = lst;

        }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BatDongSan a = grid.SelectedItem as BatDongSan;
            frmThemHDDC.stringbdsid = a.bdsid.ToString();
            frmThemHDDC frm = new frmThemHDDC();
            frm.Show();
            this.Close();
        }
    }
}
