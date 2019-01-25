using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bootcamp.CRUD.Model;

namespace Bootcamp.CRUD.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Bootcamp22") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionItem> TransactionItems { get; set; }
    }
}
