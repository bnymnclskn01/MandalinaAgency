using Mandalina.Core.ViewModel.EntityVM.Category;
using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModel.EntityVM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.ServicePage
{
    public class ServiceListPage
    {
        public List<ServiceListVM> ServiceList { get; set; }
        public List<CategoryVM> CategoryList { get; set; }
        public List<ConstantValueVM> ConstantValue { get; set; }
        public string BreadCrumbLink { get; set; }

        public bool IsCategory { get; set; }

        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
    }
}
