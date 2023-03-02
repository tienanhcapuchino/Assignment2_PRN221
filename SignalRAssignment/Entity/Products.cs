using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Entity
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Suppliers Supplier { get; set; }
        public int SupplierId { get; set; }
        public Categories Category { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
