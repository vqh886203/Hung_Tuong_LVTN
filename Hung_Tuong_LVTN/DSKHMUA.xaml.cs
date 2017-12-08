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
    /// Interaction logic for DSKHMUA.xaml
    /// </summary>
    public partial class DSKHMUA : Window
    {
        public DSKHMUA()
        {
            InitializeComponent();
        }

       

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            KhachHang a = grid.SelectedItem as KhachHang;
            frmThemHDDC.stringkhid = a.khid.ToString();
            frmThemHDDC frm = new frmThemHDDC();
            frm.Show();
            this.Close();
        }
    }
}
