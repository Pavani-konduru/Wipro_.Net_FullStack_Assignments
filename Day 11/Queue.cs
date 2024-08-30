using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace dequeue
{

    public class Employee
    {
        public string name { get; set; }
        public string gender { get; set; }
        public long contact_no { get; set; }
        private int top;

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
    public class  customQueue<T>
    {
        private LinkedList<int> List = new LinkedList<int>();
        public bool IsEmpty()
        {
            return List.Count == 0;

        }
    }
 
        class QueueEmployee
        {
            static void Main(string[] args)
            {
                Queue<Employee> employeeQueue = new Queue<Employee>();
                Console.WriteLine("-----Enqueue Operation------");
                employeeQueue.Enqueue(new Employee("Pavani", "Female", 123456789));
                employeeQueue.Enqueue(new Employee("Rani", "Female", 23416247769));
                employeeQueue.Enqueue(new Employee("Lohith", "Male", 9999567829));

                Console.WriteLine("Employess enqueue into the queue by using Enqueue");
                foreach (Employee employee in employeeQueue)
                {
                    Console.WriteLine("Employee added into queue : " + employee);
                }
                Console.WriteLine();
                Console.WriteLine("-----DeQueue Operation------");
                Employee pop = employeeQueue.Dequeue();
                Console.WriteLine("Employee by Dequeue : " + pop);
                Console.WriteLine();

                Console.WriteLine("-------Peek Operation--------");
                Employee peek = employeeQueue.Peek();
                Console.WriteLine("Employee by peek : " + peek);
                Console.WriteLine();

                Console.WriteLine($"Is Queue is Empty: {employeeQueue.Count == 0}");
            }
        }
  }
    
