using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableLib
{
    public class Product
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint QuantityInStock { get; set; }

        //настройка связей
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
