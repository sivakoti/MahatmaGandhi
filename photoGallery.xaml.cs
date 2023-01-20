using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf_GandhiSayings
{
    /// <summary>
    /// Interaction logic for photoGallery.xaml
    /// </summary>
    public partial class photoGallery : Window
    {
        public static ObservableCollection<PhotoGallery> _photos;
        public photoGallery()
        {
            InitializeComponent();
        }
        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {
            PhotoGallery photo = new PhotoGallery { description = "Gandhi At the age 7", imagePath = "/GandhiImages/1.png" };
            _photos.Add(photo);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _photos = MyStorage.ReadXml<ObservableCollection<PhotoGallery>>("Photos.xml");
            LBx_photos.ItemsSource = _photos;

            if (_photos == null)
                _photos = new ObservableCollection<PhotoGallery>();
            LBx_photos.SelectedIndex = 0;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<PhotoGallery>>(_photos, "Photos.xml");
            Owner.Visibility = Visibility.Visible;
        }

        private void Btn_prev_Click(object sender, RoutedEventArgs e)
        {
            var pos = LBx_photos.SelectedIndex - 1;
            if (pos >= 0)
                LBx_photos.SelectedIndex = pos;
            
        }

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            var pos = LBx_photos.SelectedIndex + 1;
            if (pos < LBx_photos.Items.Count)
                LBx_photos.SelectedIndex = pos;
        }
    }
}
