using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Category ickiler = new Category("İçkiler");
            Category meyveler = new Category("Meyveler");
            List<Category> categories = new List<Category>();
            categories.Add(ickiler);
            categories.Add(meyveler);

            List<Person> customers = new List<Person>() {
                new Person(1,25,"Nurlan"),
                new Person(2,19,"Feride"),
                new Person(3,29,"Kamal"),
                new Person(4,30,"Emin"),
                new Person(5,15,"Seymur"),
            };

            List<Product> products = new List<Product>()
            {
                new Product(1,"Coca-cola",2,ickiler),
                new Product(2,"Fanta",2,ickiler),
                new Product(3,"Sprite",3,ickiler),
                new Product(4,"Alma",3,meyveler),
                new Product(5,"Heyva",2,meyveler),
                new Product(6,"Nar",5,meyveler)
            };

            List<OrderHistory> orderHistories = new List<OrderHistory>()
            {
                new OrderHistory(1,1,3,4),
                new OrderHistory(2,1,1,5),
                new OrderHistory(3,2,5,3),
                new OrderHistory(4,3,5,3),
                new OrderHistory(5,4,6,6),
                new OrderHistory(6,3,1,1),
                new OrderHistory(7,5,1,8)
            };

            //----------------------------------------
            //1 nomreli userin aldiqlari

            //var prod = orderHistories.Where(p => p.CustomerId == 1);
            //foreach (OrderHistory order in prod)
            //{
            //    var user = products.First(p => p.Id == order.ProductId);
            //    Console.WriteLine(user.Name);
            //}


            //----------------------------------------
            //En cox coca-cola alan user

            //var prod = products.First(p => p.Name.ToLower() == "coca-cola").Id;
            //var orders = orderHistories.Where(p => p.ProductId == prod);
            //List<Person> people = new List<Person>();
            //foreach (OrderHistory order in orders)
            //{ 
            //    var user = customers.First(p => p.Id == order.CustomerId);
            //    people.Add(user);
            //}
            //Console.WriteLine(people.OrderBy(t => t.Age).FirstOrDefault().Name);

            //------------------------------------------------------------------------------
            //Kateqoriyalar üzrə satışların toplam dəyəri


            //foreach (Category category in categories)
            //{
            //    double lastResult = 0;
            //    var produ = products.Where(p => p.Category.Name == category.Name);
            //    foreach(Product prod in produ)
            //    {
            //        var common = orderHistories.Where(p => p.ProductId == prod.Id).Select(p=>p.Count);
            //        lastResult += common.Sum() * prod.Price;

            //    }
            //    Console.WriteLine($"{category.Name} : {lastResult} azn");
            //    Console.WriteLine("-------------------------");
            //}
            //------------------------------------------------------------------------------

            //Ən çox pul xərcləyən müştəri

            //Dictionary<string, double> keyValues = new Dictionary<string, double>();
            //foreach (Person customer in customers)
            //{

            //    double customerOutcome = 0;
            //    var custProduct = orderHistories.Where(p => p.CustomerId == customer.Id);
            //    foreach (OrderHistory order in custProduct)
            //    {
            //        var common = custProduct.Where(p => p.ProductId == order.ProductId).Select(p => p.Count);
            //        customerOutcome += common.Sum() * products.First(p => p.Id == order.ProductId).Price;
            //    }
            //    keyValues.Add(customer.Name, customerOutcome);

            //    Console.WriteLine($"{customer.Name} xerci: {customerOutcome} azn");

            //    Console.WriteLine("------------------------------------------");
            //}
            //Console.WriteLine($"En cox xercleyen customer: {keyValues.OrderBy(p => p.Value).Last().Key}");

            //------------------------------------------------------------------------------

            //OrderHistories-də bütün satılan malların sayını 1 vahid artırın

            //foreach(OrderHistory order in orderHistories)
            //{
            //    order.Count++;
            //    Console.WriteLine($"Id:{order.Id} Product Id:{order.ProductId} Customer Id:{order.CustomerId} Count:{order.Count} ");
            //}

            //------------------------------------------------------------------------------
            //Person obyektini elə dəyişin ki(interface) onun içərisindəki əlavə edəcəyiniz PrintData metodu universal olsun

            //Console.WriteLine("Users:");
            //foreach (Person person in customers)
            //{

            //    PrintResult(person);
            //}
            //Console.WriteLine("Products:");
            //foreach (Product product in products)
            //{
            //    PrintResult(product);
            //}
        }
        public static void PrintResult(ICommonFunction myObject)
        {
            Console.WriteLine(myObject.PrintData());
            Console.WriteLine("--------------------");
        }
    }

    interface ICommonFunction
    {
        string PrintData();
    }

    class Person:ICommonFunction
    {
        public Person(int i, int a, string n)
        {
            Age = a;
            Name = n;
            Id = i;
        }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int Test { get; set; }

       

        string ICommonFunction.PrintData()
        {
            return $"User name:{Name} \nUser age:{Age} \nUser id:{Id}";
        }
    }

    class Category
    {
        public Category(string n)
        {
            Name = n;
        }
        public string Name { get; set; }
    }

    class Product:ICommonFunction
    {
        public Product(int i, string n, double p, Category c)
        {
            Id = i;
            Name = n;
            Price = p;
            Category = c;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        string ICommonFunction.PrintData()
        {
            return $"Product name:{Name} \nProduct category:{Category.Name} \nProduct id:{Id}";
        }
    }

    class OrderHistory
    {
        public OrderHistory(int i, int cid, int pid, int cnt)
        {
            Id = i;
            CustomerId = cid;
            ProductId = pid;
            Count = cnt;
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
