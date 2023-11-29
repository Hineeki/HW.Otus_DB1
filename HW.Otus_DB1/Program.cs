using Npgsql;
using TableLib;

namespace HW.Otus_DB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //После того как создали все классы, описывающие записи в таблице, и создали класс DataContext
            //Описали связи в классах и в DataContext
            //Вводим в консоль диспечера пакетов (Вид => Другие окна => Консоль ДП)
            //1. Add-Migration InitialCreate
            //2. Update-Database


            //InsertToTable("Sugar", "1 kg", 1.5, 9);
            //UpdateProdPrice("Sugar", 2.5);
        }

        static void InsertToTable(string productName, string discr, decimal price, uint stock)//хз что по перегрузкам
        {
            using (DataContext db = new DataContext())
            {
                var product = new Product
                {
                    ProductName = productName,
                    Description = discr,
                    Price = price,
                    QuantityInStock = stock,
                };
                db.Products.Add(product);

                db.SaveChanges();
                Console.WriteLine("Product Added");
            }
        }

        static void UpdateProdPrice(string prodName, decimal newPrice)
        {
            using (DataContext db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.ProductName == prodName);
                if (product != null)
                {
                    product.Price = newPrice;
                    db.Update(product);
                    db.SaveChanges();
                }
                Console.WriteLine("Record Updated");
            }
        }

        static List<Order> GetAllOrders(int userId)
        {
            using (DataContext db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x=>x.UserID == userId);
                if (user != null)
                {
                    return user.Orders.ToList();
                }
                return new List<Order> { };
            }
        }

        //подрежем
        //static void EFGetOne()
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var objects = db.clients.FirstOrDefault(x => x.id == 1);
        //        Console.WriteLine(objects.first_name);
        //    }
        //}

        //static void EFDelete()
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var obj = db.clients.FirstOrDefault(x => x.id == 1);
        //        if (obj != null)
        //        {
        //            db.clients.Remove(obj);
        //            db.SaveChanges();
        //            Console.WriteLine("объект удалён");
        //        }
        //        else
        //            Console.WriteLine("объект пустой");
        //    }
        //}
    }
}
