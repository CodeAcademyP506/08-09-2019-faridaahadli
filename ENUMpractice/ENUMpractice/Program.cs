using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENUMpractice
{
    enum AccType { Fiziki, Huquqi };

    class Program
    {
       
        static void Main(string[] args)
        {
            List<Accountant> customers = new List<Accountant>() {
        new Accountant(1,25,"Kamal", AccType.Fiziki,new List<Transachistory>()
      {
       new Transachistory(1,12,35,"Academy")
    }),
        new Accountant(2,25,"Nurlan", AccType.Huquqi,new List<Transachistory>()
      {
       new Transachistory(1,12,35,"Academy")
    }),
         new Accountant(3,19,"Feride", AccType.Fiziki,new List<Transachistory>()
      {
       new Transachistory(1,12,35,"Academy")
    })
      };

            //Fizki ve Huquqi sexslerin sayini tapin

            foreach (AccType type in Enum.GetValues(typeof(AccType)))
            {
                var sameType = customers.Where(p => p.actype == type);
                Console.WriteLine($"{type} sexslerin sayi: {sameType.Count()}");
            }
        }
        
    }
  
  

    class Accountant
    {
        public Accountant(int i, int a, string n, AccType act, List<Transachistory> h)
        {
            Age = a;
            Name = n;
            Id = i;
            actype = act;
            tranzaksiya = h;
        }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public AccType actype { get; set; }

        public List<Transachistory> tranzaksiya { get; set; } = new List<Transachistory>();


    }

 

    class Transachistory
    {
        public Transachistory(int i, int date, int amount, string dst)
        {
            Id = i;
            Date = date;
            Amount = amount;
            Destination = dst;
        }
        public int Id { get; set; }
        public int Date { get; set; }
        public int Amount { get; set; }
        public string Destination { get; set; }
    }
}
