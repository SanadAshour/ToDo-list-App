using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    class TodoRepository : ITodoRepository
    {
        private AppDbContext ADC = new AppDbContext();
        public void Add(TodoItem item)
        {
            ADC.TodoItem.Add(item);
            ADC.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if(item != null)
            {
                ADC.TodoItem.Remove(item);
                ADC.SaveChanges();
            }
        }

        public List<TodoItem> GetAll()
        {
           return ADC.TodoItem.Include(c => c.Category).ToList();
        }

        public TodoItem GetById(int id)
        {
            return ADC.TodoItem.Include(c => c.Category).ToList().FirstOrDefault(t => t.Id == id);
        }

        public void Update(TodoItem item)
        {
            ADC.Update(item);
            ADC.SaveChanges();
        }
    }
}
