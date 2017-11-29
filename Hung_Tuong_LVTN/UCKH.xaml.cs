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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for UCKH.xaml
    /// </summary>
    public partial class UCKH : UserControl
    {
        private KhachHangModelView nvmd = new KhachHangModelView();
        public UCKH()
        {
            InitializeComponent();
            gridkh.ItemsSource = nvmd.getdskhlist();
        }
    }
}
