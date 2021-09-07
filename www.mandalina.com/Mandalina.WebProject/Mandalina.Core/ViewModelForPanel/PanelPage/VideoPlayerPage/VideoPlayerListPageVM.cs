using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.VideoPlayerPage
{
    public class VideoPlayerListPageVM
    {
        public class SliderListPageVM
        {
            public int Id { get; set; }

            public string ImageUrl { get; set; }


            public string Alt { get; set; }


            public string Title { get; set; }


            public string Content { get; set; }

            public int Rank { get; set; }

            public bool IsActiveted { get; set; }

            public string LanguageName { get; set; }


        }
    }
}
