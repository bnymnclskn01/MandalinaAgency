using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.ServiceForPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.WorkPage.WorkUpdatePage
{
    public class WorkUpdateVM
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int Rank { get; set; }

        public int IsActiveted { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }

        public List<ServiceForPanel> ServiceList { get; set; }
    }
}
