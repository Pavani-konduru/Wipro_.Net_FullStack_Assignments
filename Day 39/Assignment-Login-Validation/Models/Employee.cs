using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementLogin.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; } // This field must exist

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty; // Initialize to an empty string

        public string? MiddleName { get; set; } // Make MiddleName nullable

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty; // Initialize to an empty string

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; } = 0; // Initialize to 0

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty; // Initialize to an empty string

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty; // Initialize to an empty string

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty; // Initialize to an empty string

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty; // Initialize to an empty string

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 120, ErrorMessage = "Invalid Age.")]
        public int Age { get; set; } = 0; // Initialize to 0

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)] // Specify the data type for better validation
        public DateTime DateOfBirth { get; set; } = DateTime.Now; // Initialize to current date
    }
}
