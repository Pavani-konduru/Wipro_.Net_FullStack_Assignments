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
        public partial class EditEmployeePage : Page
    {
        public EditEmployeePage()
        {
            InitializeComponent();
        }  private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = EmployeeIDTextBox.Text.Trim();

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Please enter an Employee ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (employeeId == "123")
            {
                FirstNameTextBox.Text = "John";
            }
            else
            {
                MessageBox.Show("Employee not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = EmployeeIDTextBox.Text.Trim();
            string firstName = FirstNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(employeeId) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Employee details updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
