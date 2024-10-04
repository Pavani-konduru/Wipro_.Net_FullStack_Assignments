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
   
    public partial class ViewEmployeePage : Page
    {
        public ViewEmployeePage()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = EmployeeIDTextBox.Text;

            string employeeDetails = GetEmployeeDetails(employeeId);

            if (string.IsNullOrEmpty(employeeDetails))
            {
                EmployeeDetailsTextBlock.Text = "Employee not found.";
            }
            else
            {
                EmployeeDetailsTextBlock.Text = employeeDetails;
            }
        }

        private string GetEmployeeDetails(string employeeId)
        {
           
            if (employeeId == "123")
            {
                return "Name: John Doe\nPosition: Software Developer\nDepartment: IT";
            }
            return null;
        }
    }
}

