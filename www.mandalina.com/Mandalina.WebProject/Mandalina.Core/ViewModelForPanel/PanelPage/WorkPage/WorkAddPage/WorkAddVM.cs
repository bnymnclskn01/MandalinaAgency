using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.WorkPage.WorkAddPage
{
    public class WorkAddVM
    {
        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int Rank { get; set; }
        public int IsActiveted { get; set; }
    }
}
