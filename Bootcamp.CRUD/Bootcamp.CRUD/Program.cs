using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            int pilihan = 0;
            Item item = new Item();
            MyContext _context = new MyContext();
            Console.WriteLine("==========Item Data==========");
            Console.WriteLine("1. Mangae Suppliers");
            Console.WriteLine("2. Manage Items");
            Console.WriteLine("====================================");
            Console.Write("Pilihanmu : ");
            pilihan = int.Parse(Console.ReadLine());
            Console.WriteLine("====================================");
            switch (pilihan)
            {
                case 1:
                    ControllerSupplier bebas = new ControllerSupplier();
                    bebas.ManageSupplier();
                    break;

                case 2:
                    ControllerItem namanyaapa = new ControllerItem();
                    namanyaapa.ManageItem();
                    break;

                default:
                    Console.WriteLine("Your Choice is not found, try again see you later good bye.");
                    break;
            }
            Console.Read();
        }
    }
}
