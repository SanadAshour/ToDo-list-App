using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

    }
}
