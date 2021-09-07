using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.ReferencePage
{
    public class ReferenceModel
    {
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CustomerComment { get; set; }
    }
    public class RefenceListModel
    {
        public List<ReferenceModel> RefenceListsModel { get; set; }
        public List<ConstantValueVM> ConstantValue { get; set; }
        public string BreadCrumpLink { get; set; }
    }
}
