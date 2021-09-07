using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryCreate
{
    public class CategoryCreateVM
    {
        [Required]

        public string Name { get; set; }

        public string Content { get; set; }

        public string Note { get; set; }

        [Required]

        public int Rank { get; set; }

        [Required]

        public int LanguageId { get; set; }
        [Required]

        public int IsActivated { get; set; }

        public string RawSlug { get; set; }
    }
}
