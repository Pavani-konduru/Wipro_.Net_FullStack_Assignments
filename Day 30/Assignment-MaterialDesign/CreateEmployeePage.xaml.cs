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
using System.Windows.Shapes;

namespace Day_30
{
   
    public partial class CreateEmployeePage : Window
    {
        public CreateEmployeePage()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text.Trim();
            string middleName = MiddleNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string gender = MaleRadioButton.IsChecked == true ? "Male" : "Female";
            string country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DobDatePicker.SelectedDate;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(country) || !dob.HasValue)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SuccessMessageTextBlock.Text = "Employee profile created successfully!";

            ClearForm();
        }

        private void ClearForm()
        {
            FirstNameTextBox.Clear();
            MiddleNameTextBox.Clear();
            LastNameTextBox.Clear();
            MaleRadioButton.IsChecked = false;
            FemaleRadioButton.IsChecked = false;
            CountryComboBox.SelectedIndex = -1;
            DobDatePicker.SelectedDate = null;
            SuccessMessageTextBlock.Text = string.Empty;
        }
    }
}

