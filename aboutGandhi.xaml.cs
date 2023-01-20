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
    /// Interaction logic for aboutGandhi.xaml
    /// </summary>
    public partial class aboutGandhi : Window
    {
        public static ObservableCollection<Lifestages> _lifestages;
        public aboutGandhi()
        {
            InitializeComponent();
        }
       
        public void Btn_AddCategories_Click(object sender, RoutedEventArgs e)
        {
            Lifestages lif = new Lifestages { lifestage = "Introduction", timeline = "1869-1948", history = "Mohandas Karamchand Gandhi was born on 2 October 1869 into a Gujarati Hindu Modh Bania family in Porbandar which is in present day Gujarat state of India.Gandhi is the first child for Karamchand Uttam Chand Gandhi and his fouth wife Putlibai.At that time Gandhi's father served as Dewan(Chief minister) of Porbandar state of the Indian empire. As a child, Gandhi was described by his sister Raliat as 'restless as mercury, either playing or roaming about.One of his favourite pastimes was twisting dogs ears'. The Indian classics, especially the stories of Shravana and king Harishchandra, had a great impact on Gandhi in his childhood." };
            _lifestages.Add(lif);
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _lifestages = MyStorage.ReadXml<ObservableCollection<Lifestages>>("Lifestage.xml");
            LBx_Lifestages.ItemsSource = _lifestages;

            LBx_Lifestages.SelectedIndex = 0;
            if (_lifestages == null)
                _lifestages = new ObservableCollection<Lifestages>();
        }

        public void Window_Closed(object sender, EventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Lifestages>>(_lifestages, "lifestage.xml");
            Owner.Visibility = Visibility.Visible;
        }

        private void TBx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBx_filter.Text == "")
            {
                LBx_Lifestages.ItemsSource = _lifestages;
                LBx_Lifestages.SelectedIndex = 0;
            }
            else
            {
                var filter = TBx_filter.Text;
                var lst = (from c in _lifestages
                           where c.lifestage.ToLower().Contains(filter)
                           select c).ToList();
                var lst2 = (from c in _lifestages
                            where c.history.ToLower().Contains(filter)
                            select c).ToList();
                LBx_Lifestages.ItemsSource = lst;
                LBx_Lifestages.ItemsSource = lst2;
            }
        }

        private void TBx_filter_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
