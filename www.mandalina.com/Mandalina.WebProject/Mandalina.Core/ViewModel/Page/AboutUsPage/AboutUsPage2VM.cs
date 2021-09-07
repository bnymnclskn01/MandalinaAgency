using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.AboutUsPage
{
    public class AboutUsPage2VM
    {
        public List<ConstantValueVM> ConstantValue { get; set; }

        public AboutUsPageVM AboutUsPageVM { get; set; }

        public string BreadcrumpLink { get; set; }
    }
}
