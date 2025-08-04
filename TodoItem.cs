using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    class TodoItem
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TaskDate { get; set; }
        public string? Status { get; set; }
        //FK
        public int CategoryId { get; set; }
        //Navigation prop
        public Category Category { get; set; } = new Category();
    }
}
