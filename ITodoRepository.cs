using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    interface ITodoRepository
    {
        List<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Delete(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);

    }
}
