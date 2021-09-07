using Mandalina.Core.ViewModel.EntityVM.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Service
{
    public class ServiceDetail
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string Slug { get; set; }

        public int CatId { get; set; }
        public List<WorkListVM> WorkListVM { get; set; }
    }

}
