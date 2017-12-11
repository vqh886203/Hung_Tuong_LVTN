using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
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
    /// Interaction logic for Gallery.xaml
    /// </summary>
    public partial class Gallery : Window
    {
        databaseDataContext dc = new databaseDataContext();
        Size x1 = new Size(250, 250);
        Size x = new Size(500, 500);
        public Gallery()
        {
            InitializeComponent();
           
        }
        public void loadData(int ms)
        {
            foreach (HinhBD i in dc.HinhBDs.Where(x => x.bdsid == ms))
            {
                GalleryItem a = new GalleryItem();
                Image image = new Image();
                image.SetSize(x1);
                byte[] byteBLOBData = i.hinh.ToArray();
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                image.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                a.Caption = image;
                group1.Items.Add(a);
            }
        }
        private void Gallery_ItemClick(object sender, GalleryItemEventArgs e)
        {
            // if (((Image)e.Item.Caption).GetSize() != x&&e.ItemControl.GetSize()!=x)
            // {
            //     e.ItemControl.SetSize(x);
            //     ((Image)e.Item.Caption).SetSize(x);
            // }
            //else
            // {
            //     e.ItemControl.SetSize(x1);
            //     ((Image)e.Item.Caption).SetSize(x1);
            // }


            OpenImageViewPopup(e.Item);
        }
        void OpenImageViewPopup(GalleryItem item)
        {
            ShowItemInImageViewer(item);
            imageViewPopup.Visibility = Visibility.Visible;
        }
        private void ShowItemInImageViewer(GalleryItem item)
        {
            Image i = (Image)item.Caption;
            imageViewer.Source = i.Source;
            //imageViewer.Rotation = Rotation.Rotate0;
            //imageViewer.LayoutUpdated += new EventHandler(imageViewer_LayoutUpdated);
            //FitImageInViewport();
        }
        void CloseImagePopup()
        {
            imageViewPopup.Visibility = Visibility.Collapsed;

        }

        private void Gallery_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void imageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                CloseImagePopup();
            }
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            CloseImagePopup();
        }
        //void imageViewer_LayoutUpdated(object sender, EventArgs e)
        //{
        //    FitImageInViewport();
        //    imageViewer.LayoutUpdated -= new EventHandler(imageViewer_LayoutUpdated);
        //}

        //private void FitImageInViewport()
        //{
        //    if (imageViewer.ImageSource == null)
        //    {
        //        imageViewer.Scale *= 100;
        //        return;
        //    }
        //    double scaleWidth = Math.Min(1.0, (imageViewer.Viewport.ActualWidth - 20) / imageViewer.ImageSource.Width);
        //    double scaleHeight = Math.Min(1.0, (imageViewer.Viewport.ActualHeight - 20) / imageViewer.ImageSource.Height);
        //    imageViewer.Scale = 100 * Math.Min(scaleWidth, scaleHeight);
        //}

        //private void imageViewer_MouseWheelZoom(object sender, System.EventArgs e)
        //{
        //    imageViewer.Scale *= 100;
        //}
    }
}
