using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    public class InnerJoinService
    {
        private List<Customer> _customers;
        private List<Order> _orders;

        public InnerJoinService(List<Customer> customers, List<Order> orders)
        {
            _customers = customers;
            _orders = orders;
        }

        public List<OrderWithCustomerName> GetInnerJoinOrdersLamda()
        {
            return _orders
                .Join(_customers,
                      order => order.CustomerId,
                      customer => customer.Id,
                      (order, customer) => new OrderWithCustomerName
                      {
                          OrderId = order.OrderId,
                          Address = order.Address,
                          Datetime = order.Datetime,
                          CustomerName = customer.Name
                      })
                .ToList();
        }
        public List<OrderWithCustomerName> GetInnerJoinOrdersSql()
        {
            var query = from order in _orders
                        join customer in _customers
                        on order.CustomerId equals customer.Id
                        select new OrderWithCustomerName
                        {
                            OrderId = order.OrderId,
                            Address = order.Address,
                            Datetime = order.Datetime,
                            CustomerName = customer.Name
                        };

            return query.ToList();
        }
    }
}
