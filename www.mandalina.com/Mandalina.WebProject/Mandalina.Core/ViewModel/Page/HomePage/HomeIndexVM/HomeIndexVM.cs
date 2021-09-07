using Mandalina.Core.ViewModel.EntityVM;
using Mandalina.Core.ViewModel.EntityVM.AboutUs;
using Mandalina.Core.ViewModel.EntityVM.Category;
using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModel.EntityVM.Service;
using Mandalina.Core.ViewModel.EntityVM.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.HomePage.HomeIndexVM
{
    public class HomeIndexVM
    {
        public List<MainSliderVM> SliderList { get; set; }
        public List<MainVideoPlayerVM> VideoPlayerList { get; set; }
        public List<ServiceForHome> ServicesList { get; set; }
        public List<ConstantValueVM> ConstantValue { get; set; }
        public AboutUsVM AboutUsVM { get; set; }
        public SendOfferMail.SendOfferMail SendOfferMail { get; set; }
        public List<CategoryVM> CategoryList { get; set; }
    }
}
