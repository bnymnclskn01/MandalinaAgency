using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Work
{
    public class WorkListVM
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int Rank { get; set; }

        public int ServiceId { get; set; }
    }
}
