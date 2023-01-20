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

namespace Wpf_GandhiSayings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_sayings_Click(object sender, RoutedEventArgs e)
        {
            var newwin_sayings = new Sayings();
            newwin_sayings.Owner = this;
            this.Visibility = Visibility.Collapsed;
            newwin_sayings.Width = Width;
            newwin_sayings.Height = Height;
            newwin_sayings.Show();
            
        }

        private void Btn_aboutGandhi_Click(object sender, RoutedEventArgs e)
        {
            var newwin_about = new aboutGandhi();
            newwin_about.Owner = this;
            this.Visibility = Visibility.Collapsed;
            newwin_about.Width = Width;
            newwin_about.Height = Height;
            newwin_about.Show();
        }

        private void Btn_photoGallery_Click(object sender, RoutedEventArgs e)
        {
            var newwin_photo = new photoGallery();
            newwin_photo.Owner = this;
            this.Visibility = Visibility.Collapsed;
            newwin_photo.Width = Width;
            newwin_photo.Height = Height;
            newwin_photo.Show();
        }
    }
}
