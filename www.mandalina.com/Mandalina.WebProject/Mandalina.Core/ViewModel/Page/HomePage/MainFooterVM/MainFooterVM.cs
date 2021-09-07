using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModel.EntityVM.ContactInformation;
using Mandalina.Core.ViewModel.EntityVM.Menu;
using Mandalina.Core.ViewModel.EntityVM.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.HomePage.MainFooterVM
{
    public class MainFooterVM
    {

        public List<MenuVM> FooterMenuVM { get; set; }

        public List<MenuVM> SmallFooterMenuVM { get; set; }

        public List<ConstantValueVM> ConstantValueVM { get; set; }

        public List<MenuVM> UnderFooterMenuVM { get; set; }

        public List<SocialMediaVM> SocialMediaVM { get; set; }

        public ContactInformationVM ContactInformationVM { get; set; }
    }
}
