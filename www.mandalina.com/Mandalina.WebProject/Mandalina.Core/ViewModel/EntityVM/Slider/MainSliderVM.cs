using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Slider
{
    public class MainSliderVM
    {
        public List<SliderImageVm> SliderImage { get; set; }
        public string ImageUrl { get; set; }


        public string Slogans { get; set; }


        public string Title { get; set; }


        public string Content { get; set; }

    }

    public class SliderImageVm
    {
        public string ImageUrl { get; set; }
        public int Rank { get; set; }
    }
}
