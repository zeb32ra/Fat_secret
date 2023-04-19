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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    //
    public partial class Page1 : Page
    {
        string curr_date;
        int days = 0;
        public Page1()
        {
            InitializeComponent();
            Date_pick.SelectedDate = DateTime.Today.Date; ;
            
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Date_pick.SelectedDate = Date_pick.SelectedDate.Value.AddDays(30);
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            Date_pick.SelectedDate = Date_pick.SelectedDate.Value.AddDays(-30);
        }

        private void Date_pick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            days = DateTime.DaysInMonth(Date_pick.SelectedDate.Value.Year, Date_pick.SelectedDate.Value.Month);
            m_y_text.Text = Date_pick.SelectedDate.Value.ToString("MMMM") + " " + Date_pick.SelectedDate.Value.Year.ToString();
            panel.Children.Clear();
            display_icons();
        }

        private void display_icons()
        {
            for (int i = 1; i < days + 1; i++)
            {
                Icon icon = new Icon();
                icon.icon_text.Text = i.ToString();
                panel.Children.Add(icon);
            }
        }
    }
}
