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
        string date_today = "";
        List<Choise_for_day> today_choise = Generics.MyDeserialize<List<Choise_for_day>>("Choises.json");
        public Page2(string date_day)
        {
            InitializeComponent();
            date_today = date_day;
            load();
            date.Text = date_today;
            food_list.ItemsSource = punkts;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Pg_frame.Content = new Page1();
        }

        private void load()
        {
            if (today_choise == null)
            {
                today_choise = new List<Choise_for_day>();
            }
            if (today_choise.Count > 0)
            {
                foreach(Choise_for_day i in today_choise)
                {
                    if(i.date == date_today)
                    {
                        foreach(Punktti j in i.punkts_for_day)
                        {
                            punkts.Add(j);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < pictures.Count; i++)
                {
                    Punktti punkt = new Punktti(false, pictures[i], titles[i]);
                    punkts.Add(punkt);
                }

                List<Punktti> cop = new List<Punktti>();
                foreach (Punktti p in punkts)
                {
                    cop.Add(p);
                }
                Choise_for_day ch = new Choise_for_day(date_today, cop);
                today_choise.Add(ch);
            }  
        }

        private void Save_back_Click(object sender, RoutedEventArgs e)
        {
            foreach (Choise_for_day choise in today_choise)
            {
                if (choise.date == date_today)
                {
                    choise.punkts_for_day.Clear();
                    foreach (Punktti i in food_list.Items)
                    {
                        choise.punkts_for_day.Add(i);
                    }
                }
            }
            Generics.MySerialize(today_choise, "Choises.json");
            (Application.Current.MainWindow as MainWindow).Pg_frame.Content = new Page1();
        }
    }
}
