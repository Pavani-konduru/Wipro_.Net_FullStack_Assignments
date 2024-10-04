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

namespace Day_29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       // public object ErrorMessageTextBlock { get; private set; }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous messages
            //ErrorMessageTextBlock.Text = string.Empty;
            SuccessMessageTextBlock.Text = string.Empty;

            // Get values from controls
            string firstName = FirstNameTextBox.Text;
            if (String.IsNullOrEmpty(firstName))
                {
                FirstNameError.Content = "Please Provide First Name";
            }
            string middleName = MiddleNameTextBox.Text;
            if (String.IsNullOrEmpty(middleName))
            {
                MiddleNameError.Content = "Please Provide Middle Name";
            }
            string lastName = LastNameTextBox.Text;
            if (String.IsNullOrEmpty(lastName))
            {
                LastNameError.Content = "Please Provide Last Name";
            }
            string gender = MaleRadioButton.IsChecked == true ? "Male" : FemaleRadioButton.IsChecked == true ? "Female" : string.Empty;
            string country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DobDatePicker.SelectedDate;
          if (dob != null)
            {
           
                    DateError.Content = "Please Provide a valid D.O.B";
               
            }


             // Display success message if no errors
             if (string.IsNullOrEmpty(SuccessMessageTextBlock.Text))
             {
                 SuccessMessageTextBlock.Text = "Form submitted successfully!";
             }
        }
    }
}
    

