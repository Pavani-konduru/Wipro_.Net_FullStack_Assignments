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

namespace Day_30
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DashboardMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateEmployeePage());
        }

        private void CreateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateEmployeePage());
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditEmployeePage());
        }

        private void ViewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewEmployeePage());
        }
    }

}

