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
            bool found = false;
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
                        found = true;
                        foreach(PunkttiDTO j in i.punkts_for_day)
                        {
                            Punktti p = new Punktti(j.isCheked, j.img_path, j.title);
                            punkts.Add(p);
                        }
                    }
                }
                if (!found)
                {
                    for (int i = 0; i < pictures.Count; i++)
                    {
                        Punktti punkt = new Punktti(false, pictures[i], titles[i]);
                        punkts.Add(punkt);
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
            }  
        }

        private void Save_back_Click(object sender, RoutedEventArgs e)
        {
            List<PunkttiDTO> flist_punkts = new List<PunkttiDTO> ();
            foreach(Punktti punkt in food_list.Items)
            {
                PunkttiDTO p = new PunkttiDTO(punkt.ischecked, punkt.img_path, punkt.title);
                flist_punkts.Add(p);
            }

            if(today_choise.Count == 0)
            {
                Choise_for_day new_chd = new Choise_for_day(date_today, flist_punkts);
                today_choise.Add(new_chd);
            }
            else
            {
                try
                {
                    bool found = false;
                    foreach (Choise_for_day choise in today_choise)
                    {
                        if (choise.date == date_today)
                        {
                            found = true;
                            today_choise.Remove(choise);
                            Choise_for_day ch = new Choise_for_day(date_today, flist_punkts);
                            today_choise.Add(ch);
                        }
                    }
                    if (!found)
                    {
                        Choise_for_day new_chd = new Choise_for_day(date_today, flist_punkts);
                        today_choise.Add(new_chd);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("OK");
                }
            }
            Generics.MySerialize(today_choise, "Choises.json");
            (Application.Current.MainWindow as MainWindow).Pg_frame.Content = new Page1();
        }
    }
}
