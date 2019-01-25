using Bootcamp.CRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    class controllerTransaction
    {
        public void ManageTransaction()
        {
            Transaction transaction = new Transaction();
            MyContext _context = new MyContext();

            transaction.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            transaction.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            ControllerTransactionItem bingung = new ControllerTransactionItem();
            bingung.ManageTransactionItem();
        }
    }
}
