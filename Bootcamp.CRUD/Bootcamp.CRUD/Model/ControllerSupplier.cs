using Bootcamp.CRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    public class ControllerSupplier
    {
        public void ManageSupplier()
        {
            int pilihan = 0;
            var result = 0;
            Supplier supplier = new Supplier();
            MyContext _context = new MyContext();
            Console.WriteLine("==========Supplier Data==========");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("====================================");
            Console.Write("Pilihanmu : ");
            pilihan = int.Parse(Console.ReadLine());
            Console.WriteLine("====================================");
            switch (pilihan)
            {
                case 1:
                    Console.WriteLine("==========Supplier Data==========");
                    Console.WriteLine("====================================");
                    Console.Write("Insert Name Of Supplier : ");
                    supplier.Name = Console.ReadLine();
                    supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                    supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;

                    _context.Suppliers.Add(supplier);
                    result = _context.SaveChanges();
                    if (result > 0)
                    {
                        Console.WriteLine("insert Successfully");
                    }
                    else
                    {
                        Console.WriteLine("insert Failed");
                    }
                    Console.WriteLine("====================================");
                    break;

                case 2:
                    Console.WriteLine("============Supplier Data===========");
                    Console.WriteLine("====================================");
                    Console.Write("Insert Id to Update Data :");
                    int id = Convert.ToInt16(Console.ReadLine());
                    var get = _context.Suppliers.Find(id);
                    if (get == null)
                    {
                        Console.Write("Sorry, your data is not found");
                    }
                    else
                    {
                        Console.Write("Insert Name of Supplier : ");
                        get.Name = Console.ReadLine();
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.WriteLine("insert Successfully");
                        }
                        else
                        {
                            Console.WriteLine("insert Failed");
                        }
                        Console.WriteLine("====================================");
                    }
                    break;

                case 3:
                    Console.WriteLine("============Supplier Data===========");
                    Console.WriteLine("====================================");
                    Console.Write("Insert Id to Delete Data :");
                    var getdata = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));
                    if (getdata == null)
                    {
                        Console.Write("Sorry, your data is not found");
                    }
                    else
                    {
                        getdata.IsDelete = true;
                        getdata.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.WriteLine("Delete Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Delete Failed");
                        }
                    }
                    Console.WriteLine("====================================");
                    break;

                case 4:
                    var getDatatoDisplay = _context.Suppliers.Where(x => x.IsDelete == false).ToList();

                    if (getDatatoDisplay.Count == 0)
                    {
                        Console.WriteLine("No data in your Database");
                    }
                    else
                    {
                        foreach (var tampilin in getDatatoDisplay)
                        {
                            Console.WriteLine("================================");
                            Console.WriteLine("Name      : " + tampilin.Name);
                            Console.WriteLine("Join Date : " + tampilin.JoinDate);
                            Console.WriteLine("================================");
                        }
                        Console.WriteLine("Total Supplier " + getDatatoDisplay.Count);
                    }
                    Console.WriteLine("====================================");
                    break;

                default:
                    Console.WriteLine("Your Choice is not found, try again see you later good bye.");
                    break;
            }
            Console.Read();
        }
    }
}
