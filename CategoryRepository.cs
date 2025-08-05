using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    class CategoryRepository : ICategoryRepository
    {
        private AppDbContext ADC = new AppDbContext();
        public List<Category> GetAll()
        {
            return ADC.Categories.ToList();
        }
    }
}
