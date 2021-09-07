using Mandalina.Core.ViewModel.EntityVM.Category;
using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModel.EntityVM.Service;
using Mandalina.Core.ViewModel.EntityVM.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.ServiceDetailPage
{
    public class ServiceDetailPage
    {
        public List<ConstantValueVM> ConstantValue { get; set; }

        public List<SocialMediaVM> SocialMediasVM { get; set; }

        public ServiceDetail ServiceDetails { get; set; }

        public string BreadCrumbLink { get; set; }

        public string CategoryName { get; set; }

        public string CategorySlug { get; set; }
        public List<CategoryVM> CategoryList { get; set; }

    }
}
