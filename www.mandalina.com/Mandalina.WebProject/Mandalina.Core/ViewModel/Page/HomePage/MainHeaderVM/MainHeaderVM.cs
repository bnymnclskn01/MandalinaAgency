using Mandalina.Core.ViewModel.EntityVM;
using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModel.EntityVM.Language;
using Mandalina.Core.ViewModel.EntityVM.Menu;
using Mandalina.Core.ViewModel.EntityVM.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.HomePage.MainHeaderVM
{
    public class MainHeaderVM
    {

        public List<ConstantValueVM> ConstantValueVM { get; set; }

        public List<MenuVM> MenuVM { get; set; }

        public List<LanguageVM> LanguageVM { get; set; }

        public List<SocialMediaVM> SocialMediaVM { get; set; }
        public List<MainVideoPlayerVM> VideoPlayerList { get; set; }

        public string FormLink { get; set; }

    }
}
