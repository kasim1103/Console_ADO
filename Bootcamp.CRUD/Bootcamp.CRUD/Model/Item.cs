using Bootcamp.CRUD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    public class Item : BaseModel
    {
        public string name { get; set; }
        public int stock { get; set; }
        public DateTimeOffset InsertDate { get; set; }
    }
}
