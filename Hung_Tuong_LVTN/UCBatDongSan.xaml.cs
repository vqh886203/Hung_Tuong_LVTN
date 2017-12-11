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
    /// Interaction logic for UCBatDongSan.xaml
    /// </summary>
    public partial class UCBatDongSan : UserControl
    {
        databaseDataContext dc = new databaseDataContext();
        SuaBDS eBDS;
        public UCBatDongSan()
        {
            InitializeComponent();
        }
        private void grid_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {

        }


        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BDSView card = grid.SelectedItem as BDSView;
            if (card == null) return;
            eBDS = new SuaBDS();
            eBDS.setBDS(card.bdsid);
            eBDS.Show();

        }
        private void Card_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            BDSView card = grid.SelectedItem as BDSView;
            frmGallery gallery = new frmGallery();
            gallery.loadData(card.bdsid);
            gallery.Show();
        }

    }
}
