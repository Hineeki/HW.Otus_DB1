using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableLib
{
    public class Order
    {
        public long OrderID { get; set; }
        public long UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public StatusEnum Status { get; set; }

        //настройка связей
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
