using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Entity
{
    public class Orders
    {
        public int OrderId { get; set; }
        public Customers Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipAddress { get; set; }
    }
}
