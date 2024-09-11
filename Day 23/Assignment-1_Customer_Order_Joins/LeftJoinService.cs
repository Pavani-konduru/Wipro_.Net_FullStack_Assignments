using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    public class LeftJoinService
    {
        private List<Customer> _customers;
        private List<Order> _orders;

        public LeftJoinService(List<Customer> customers, List<Order> orders)
        {
            _customers = customers;
            _orders = orders;
        }

        public List<OrderWithCustomerName> GetLeftJoinOrdersLamda()
        {
            return _orders
                .GroupJoin(_customers,
                           order => order.CustomerId,
                           customer => customer.Id,
                           (order, customerGroup) => new
                           {
                               order,
                               customer = customerGroup.FirstOrDefault()
                           })
                .Select(result => new OrderWithCustomerName
                {
                    OrderId = result.order.OrderId,
                    Address = result.order.Address,
                    Datetime = result.order.Datetime,
                    CustomerName = result.customer?.Name ?? "Unknown"
                })
                .ToList();
        }
        public List<OrderWithCustomerName> GetLeftJoinOrdersLinq()
        {
            var query = from order in _orders
                        join customer in _customers
                        on order.CustomerId equals customer.Id into customerGroup
                        from customer in customerGroup.DefaultIfEmpty()
                        select new OrderWithCustomerName
                        {
                            OrderId = order.OrderId,
                            Address = order.Address,
                            Datetime = order.Datetime,
                            CustomerName = customer?.Name ?? "Unknown"
                        };

            return query.ToList();
        }
    }
}
