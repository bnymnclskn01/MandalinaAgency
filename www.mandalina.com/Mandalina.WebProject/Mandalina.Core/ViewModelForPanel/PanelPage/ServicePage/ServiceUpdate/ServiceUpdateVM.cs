using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.CategoryForPanel;
using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.ServicePage.ServiceUpdateVM
{
    public class ServiceUpdateVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string RawSlug { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string ShortText { get; set; }

        [Required]
        public int Rank { get; set; }
        [Required]
        public int IsActiveted { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public int CategoryId { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }

        public List<CategoryForPanel> CategoryList { get; set; }
    }
}
