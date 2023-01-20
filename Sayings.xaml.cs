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
    /// Interaction logic for Sayings.xaml
    /// </summary>
    public partial class Sayings : Window
    {
        public static ObservableCollection<Category> _categories;
        public Sayings()
        {
            InitializeComponent();
        }
       
        public void Btn_AddCategories_Click( object sender, RoutedEventArgs e)
        {
            Category cat = new Category { categoryName = "Human kind", Saying = "A man is but the product of his thoughts.What he thinks,he becomes."};
            _categories.Add(cat);
            var lst = (from b in _categories where b.categoryName == "Human kind" select b).ToList();
            LBx_Sayings.ItemsSource = lst;
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _categories = MyStorage.ReadXml<ObservableCollection<Category>>("Categories.xml");  
            LBx_Categories.ItemsSource = Resource.Category.Split(',');
            LBx_Categories.SelectedIndex = 0;

            if (_categories == null)
                _categories = new ObservableCollection<Category>();
        }

        public void Window_Closed(object sender, EventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Category>>(_categories,"Categories.xml");
            Owner.Visibility = Visibility.Visible;
        }
        
        private void LBx_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = LBx_Categories.SelectedItem.ToString();
            var lst = (from b in _categories where b.categoryName == sel select b).ToList();
            LBx_Sayings.ItemsSource = lst;
            Stk_sayings.Visibility = Visibility.Hidden;
            this.Width = 700;
        }

        private void Btn_AddSaying_Click(object sender, RoutedEventArgs e)
        {
            Stk_sayings.Visibility = Visibility.Visible;
            this.Width = 850;

        }

        private void Btn_useradd_Click(object sender, RoutedEventArgs e)
        {
            var say = Tbx_addSaying.Text;
            Category usercat = new Category { categoryName="User sayings", Saying=say};
            _categories.Add(usercat);
            Stk_sayings.Visibility = Visibility.Hidden;
            this.Width = 700;
            LBx_Categories.SelectedIndex = 5;
        }

        private void TBx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBx_filter.Text == "")
            {
                LBx_Sayings.ItemsSource = _categories;
            }
            else
            {
                var filter = TBx_filter.Text;
                var lst = (from c in _categories
                           where c.Saying.ToLower().Contains(filter)
                           select c).ToList();
                LBx_Sayings.ItemsSource = lst;
            }
        }
    }
}