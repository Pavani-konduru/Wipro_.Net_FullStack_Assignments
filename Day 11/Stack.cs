using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Employee
    {
        public string name { get; set; }
        public string gender { get; set; }
        public long contact_no { get; set; }

        public Employee(string name, string gender, long contact_no)
        {
            this.name = name;
            this.gender = gender;
            this.contact_no = contact_no;
        }
        public override string ToString()
        {
            return $"Name: {name}, Gender: {gender}, Contacts: {contact_no}";
        }
    }
    public class customStack<T>
    {
        private LinkedList<int> List = new LinkedList<int>();
        public bool IsEmpty()
        {
            return List.Count == 0;
        }
    }
    public class StackEmployee
    {
        public static void Main(string[] args)
        {
            Stack<Employee> employeeStack = new Stack<Employee>();

            employeeStack.Push(new Employee("pavani", "female", 123456789));
            Console.WriteLine("-----Push Operation----");
            Console.WriteLine("Employee pavani pushed into the stack");
            employeeStack.Push(new Employee("Latha", "female", 9999383879));
            Console.WriteLine("Employee Latha pushed into the stack");
            Console.WriteLine();

            Console.WriteLine("-----Pop Operation----");
            Employee pop = employeeStack .Pop();
            Console.WriteLine("Pop : " + pop);
            Console.WriteLine();

            Console.WriteLine("-----Peek Operation----");
            Employee peek =  employeeStack .Peek();
            Console.WriteLine("Peek : " + peek);
            Console.WriteLine();

            Console.WriteLine($"Is Stack Empty: {employeeStack.Count == 0}");         
        }
    }
}

