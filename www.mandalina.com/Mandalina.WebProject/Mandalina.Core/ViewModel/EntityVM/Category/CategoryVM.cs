using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Category
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PropertyId { get; set; }
        public string Content { get; set; }


        public string Photo { get; set; }


        public string CategorySlug { get; set; }
    }
}
