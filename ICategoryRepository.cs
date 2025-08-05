using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
