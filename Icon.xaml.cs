﻿using System;
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
    /// Логика взаимодействия для Icon.xaml
    /// </summary>
    public partial class Icon : UserControl
    {
        // list of punkts
        string date_day;
        public Icon()
        {
            InitializeComponent();
        }

        private void pic_but_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Pg_frame.Content = new Page2();
        }
    }
}
