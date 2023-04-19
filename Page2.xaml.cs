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

namespace Fat_Secret
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public static Uri steak = new Uri("pack://application:,,,/Images/steak.png");
        public static Uri fish = new Uri("pack://application:,,,/Images/fish.png");
        public static Uri soup = new Uri("pack://application:,,,/Images/soup.png");
        public static Uri spaghetti = new Uri("pack://application:,,,/Images/spaghetti.png");
        public static Uri cake = new Uri("pack://application:,,,/Images/cake.png");

        public static string title1 = "Стейк из свинины";
        public static string title2 = "Запеченая рыба";
        public static string title3 = "Грибной крем суп";
        public static string title4 = "Спагетти болоньезе";
        public static string title5 = "Панчо с ананасами";

        List<Uri> pictures = new List<Uri>() { steak, fish, soup, spaghetti, cake };
        List<string> titles = new List<string>() {title1, title2, title3, title4, title5};
        List<Punktti> punkts = new List<Punktti>();
        public Page2()
        {
            InitializeComponent();
            load();
            food_list.ItemsSource = punkts;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Pg_frame.Content = new Page1();
        }

        private void load()
        {
            for(int i = 0; i < pictures.Count; i++)
            {
                Punktti punkt = new Punktti(false, pictures[i], titles[i]);
                punkts.Add(punkt);
            }
        }
    }
}
