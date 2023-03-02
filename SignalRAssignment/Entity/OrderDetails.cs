using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Entity
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public Orders Order { get; set; }
        public int OrderId { get; set; }
        public Products Product { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
