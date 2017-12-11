using Microsoft.Reporting.WinForms;
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

namespace Hung_Tuong_LVTN.RP
{
    /// <summary>
    /// Interaction logic for WindowRPhddc.xaml
    /// </summary>
    public partial class WindowRPhddc : Window
    {
        public object data;
        public WindowRPhddc()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rv.Clear();
            ReportDataSource rpd = new ReportDataSource();
            rpd.Value = data;
            rpd.Name = "DataSetHDDC";
            rv.LocalReport.ReportEmbeddedResource = "Hung_Tuong_LVTN.RP.ReportHDDC.rdlc";
            rv.LocalReport.DataSources.Add(rpd);
            rv.RefreshReport();
        }
    }
}
