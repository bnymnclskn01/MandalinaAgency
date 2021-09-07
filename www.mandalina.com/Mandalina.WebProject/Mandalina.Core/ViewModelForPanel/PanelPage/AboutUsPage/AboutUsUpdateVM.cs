using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.AboutUsPage
{
    public class AboutUsUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string AboutUsContent { get; set; }
        [Required]

        public string VisionContent { get; set; }
        [Required]

        public string MissionContent { get; set; }

    }
}
