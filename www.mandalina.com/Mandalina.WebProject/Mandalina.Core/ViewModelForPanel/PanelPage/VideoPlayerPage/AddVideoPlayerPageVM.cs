using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.VideoPlayerPage
{
    public class AddVideoPlayerPageVM
    {
        [Required]
        public int LanguageId { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public int Rank { get; set; }

        public int IsActiveted { get; set; }
        public List<LanguageForPanel> LanguageList { get; set; }
    }
}
