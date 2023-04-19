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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fat_Secret
{
    /// <summary>
    /// Логика взаимодействия для Punktti.xaml
    /// </summary>
    public partial class Punktti : UserControl
    {
        bool ischecked;
        Uri img_path;
        string title;

        public Punktti(bool isch, Uri imp, string t)
        {
            InitializeComponent();
            img_path = imp;
            title = t;
            ischecked = isch;
            eaten.IsChecked = ischecked;
            food_img.Source = new BitmapImage(img_path);
            food_text.Text = title;
        }


        private void eaten_Checked(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
