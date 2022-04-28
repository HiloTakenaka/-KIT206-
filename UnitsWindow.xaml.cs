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

namespace KIT206
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class UnitsWindow : Window
    {
        public UnitsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            StaffWindow staffWin = new StaffWindow();
            staffWin.InitializeComponent(); 
            staffWin.Show();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.InitializeComponent();
            window.Show();
        }

        private void Button_Click_Units(object sender, RoutedEventArgs e)
        {

        }
    }
}
