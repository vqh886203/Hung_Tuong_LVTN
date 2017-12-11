using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hung_Tuong_LVTN
{
    /// <summary>
    /// Interaction logic for frmGallery.xaml
    /// </summary>
    public partial class frmGallery : Window
    {
        int maso;
        databaseDataContext dc = new databaseDataContext();
        public frmGallery()
        {
            InitializeComponent();
        }
        public void loadData(int ms)
        {
            maso = ms;
            foreach (HinhBD i in dc.HinhBDs.Where(x => x.bdsid == ms))
            {
                //Border border = new Border();
                //SolidColorBrush solid = new SolidColorBrush();
                //solid.Color = Color.FromArgb(0, 238, 238, 238);
                //border.Background =solid;
                //border.BorderThickness = new Thickness(2);

                GalleryItem a = new GalleryItem();
                Image image = new Image();
                image.SetSize(new Size(250, 250));
                if (i.hinh == null || i.hinh.Length <= 5)
                {
                    dc.HinhBDs.DeleteOnSubmit(i);
                    dc.SubmitChanges();
                    continue;
                }
                byte[] byteBLOBData = i.hinh.ToArray();
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                image.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                a.Caption = image;
                a.Tag = i.hinhid;
                group1.Items.Add(a);

            }
        }

        private void Gallery_ItemClick(object sender, GalleryItemEventArgs e)
        {

            imageViewer.Tag = e.Item;
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
            imageViewer.Tag = item;

            //imageViewer.Rotation = Rotation.Rotate0;
            //imageViewer.LayoutUpdated += new EventHandler(imageViewer_LayoutUpdated);
            //FitImageInViewport();
        }
        void CloseImagePopup()
        {
            imageViewPopup.Visibility = Visibility.Collapsed;
        }




        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            CloseImagePopup();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            ShowItemInImageViewer(GetNextItem(imageViewer.Tag as GalleryItem));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowItemInImageViewer(GetPriorItem(imageViewer.Tag as GalleryItem));

        }
        GalleryItem GetNextItem(GalleryItem item)
        {

            return GetItem(item, true);
        }
        GalleryItem GetPriorItem(GalleryItem item)
        {
            return GetItem(item, false);
        }
        GalleryItem GetItem(GalleryItem item, bool next)
        {
            if (item == null)
                return null;
            var coeff = next ? 1 : -1;
            var itemIndex = item.Group.Items.IndexOf(item) + coeff;
            if (item.Group.Items.IsValidIndex(itemIndex))
                return item.Group.Items[itemIndex];
            var groups = item.Group.Gallery.Groups;
            var groupIndex = (groups.IndexOf(item.Group) + coeff + groups.Count) % groups.Count;
            var group = groups[groupIndex];
            return next ? group.Items.First() : group.Items.Last();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {

            foreach (HinhBD hinh in dc.HinhBDs.Where(x => x.hinhid == int.Parse(((GalleryItem)imageViewer.Tag).Tag.ToString())))
            {

                hinh.hinh = imageViewer.Source == null ? null : ConvertToBytes(imageViewer.Source as BitmapImage);
                dc.SubmitChanges();
                MessageBox.Show("Sửa Thành Công !");
                group1.Items.Clear();
                loadData(maso);
                CloseImagePopup();
            }
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
    
    }
}
