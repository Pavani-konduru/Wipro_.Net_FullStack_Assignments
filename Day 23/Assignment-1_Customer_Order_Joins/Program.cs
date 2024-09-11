using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Pavani", Gender = "F", Age = 29, Pincode = "12345" },
            new Customer { Id = 2, Name = "Bhavana", Gender = "F", Age = 25, Pincode = "67890" }
        };

            var orders = new List<Order>
        {
            new Order { OrderId = 101, Address = "Oasis opp", Datetime = DateTime.Now, CustomerId = 1 },
            new Order { OrderId = 102, Address = "KEB Colony", Datetime = DateTime.Now, CustomerId = 2 },
            new Order { OrderId = 103, Address = "B.M.R Colony", Datetime = DateTime.Now, CustomerId = 3 } 
        };

            var innerJoinService = new InnerJoinService(customers, orders);
            var leftJoinService = new LeftJoinService(customers, orders);
            var rightJoinService = new RightJoinService(customers, orders);
            var fullOuterJoinService = new FullOuterJoinService(customers, orders);

            Console.WriteLine("Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Gender: {customer.Gender}, Age: {customer.Age}, Pincode: {customer.Pincode}");
            }

            Console.WriteLine("\nOrders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, Address: {order.Address}, Datetime: {order.Datetime}, CustomerId: {order.CustomerId}");
            }



            Console.WriteLine("-------Using Lamda-------");
            Console.WriteLine();
            Console.WriteLine("Inner Join Using Lamda:");
            PrintOrderList(innerJoinService.GetInnerJoinOrdersLamda());

            Console.WriteLine("\nLeft Join Using Lamda:");
            PrintOrderList(leftJoinService.GetLeftJoinOrdersLamda());
           
            //Console.WriteLine("\nRight Join Using Lamda:");
            //PrintOrderList(rightJoinService.GetRightJoinOrders());

           // Console.WriteLine("\nFull Outer Join Using Lamda:");
           // PrintOrderList(fullOuterJoinService.GetFullOuterJoinOrders());

            Console.WriteLine("------Uising SQL Query------");
            Console.WriteLine();
            Console.WriteLine("Inner Join Using Sql Query");
            PrintOrderList(innerJoinService.GetInnerJoinOrdersSql());
            Console.WriteLine();
            Console.WriteLine("Left Join Using Sql Query");
            PrintOrderList(leftJoinService.GetLeftJoinOrdersLinq());
        }
        static void PrintOrderList(List<OrderWithCustomerName> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, Address: {order.Address}, DateTime: {order.Datetime}, CustomerName: {order.CustomerName}");
            }
        }
    }
}
