using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryUpdate
{
    public class CategoryUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }


        public string Content { get; set; }

        public string Note { get; set; }

        public int Rank { get; set; }


        [Required]

        public int LanguageId { get; set; }

        [Required]

        public int IsActivated { get; set; }


        public string RawSlug { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }
    }
}
