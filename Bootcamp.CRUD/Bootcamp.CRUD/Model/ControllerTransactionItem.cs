using Bootcamp.CRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    class ControllerTransactionItem
    {
        public void ManageTransactionItem()
        {
            int pilihan = 0;
            int? count = 0;
            TransactionItem transactionitem = new TransactionItem();
            MyContext _context = new MyContext();

            var getDatatoDisplay = _context.Items.Where(x => x.IsDelete == false).ToList();
            if (getDatatoDisplay.Count == 0)
            {
                Console.WriteLine("No data in your Database");
            }
            else
            {
                Console.WriteLine("========== List Item ===============");
                Console.WriteLine("====================================");
                foreach (var tampilin in getDatatoDisplay)
                {
                    Console.WriteLine(tampilin.id + ". " + tampilin.name);
                }
                Console.WriteLine("====================================");
                Console.Write("Pilihanmu : ");
                pilihan = int.Parse(Console.ReadLine());
                Console.WriteLine("====================================");
                Console.Write("Jumlah Item Yang Akan Dibeli : ");
                count = int.Parse(Console.ReadLine());
            }

            if (count == null)
            {
                Console.Write("Masukkan Jumlah Item Yang Akan Dibeli Terlebih Dahulu ");
                Console.Read();
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    var getTransactionId = _context.Transactions.Max(x => x.id);
                    var getTransactionDetails = _context.Transactions.Find(getTransactionId);
                    var getItem = _context.Items.Find(pilihan);
                    if (getItem == null)
                    {
                        Console.Write("we don't have this item.");
                    }
                    else
                    {
                        transactionitem.Items = getItem;
                        transactionitem.Transactions = getTransactionDetails;

                        Console.Write("Masukkan Jumlah Yang akan di Beli : ");
                        transactionitem.quantity = Convert.ToInt16(Console.ReadLine());
                        _context.TransactionItems.Add(transactionitem);
                        _context.SaveChanges();

                        Console.WriteLine("Transaction ID : " + transactionitem.id);
                        Console.WriteLine(transactionitem.Transactions.TransactionDate.DateTime);
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine(" Name          Quantity          Price        Total");
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Total                                         ");
                        Console.WriteLine("Balance                                       ");
                        Console.WriteLine("Exchange                                      ");

                        Console.Read();

                    }
                }
            }
        }
    }
}
