using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableLib
{
    public class User
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        //настройка связей
        public ICollection<Order> Orders { get; set; }
    }
}
