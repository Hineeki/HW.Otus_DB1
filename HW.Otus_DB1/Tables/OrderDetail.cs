using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableLib
{
    public class OrderDetail
    {
        public long OrderDetailID { get; set; }
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }

        //настройка связей
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
