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

    public partial class MainWindow : Window
    {
        private Unit unit;
        public MainWindow()
        {
            InitializeComponent();
            unit = (Unit)FindResource("Unit");
        }

        private void Button_Click_Units(object sender, RoutedEventArgs e)
        {
            var unitWindow = new UnitsWindow();
            unitWindow.InitializeComponent();
            unitWindow.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.InitializeComponent();
            staffWindow.Show();
        }
    }
}
