using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class ServiceCategory
    {
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int CategoriesID { get; set; }
        public Categories Categories { get; set; }
    }
}
