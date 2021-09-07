using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.ReferencePage
{
    public class ReferencePageVM
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CustomerComment { get; set; }
        public bool IsActive { get; set; }
        public string LanguageName { get; set; }
        public int Rank { get; set; }

    }

    public class AddReferencePageVM
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CustomerComment { get; set; }
        public int Rank { get; set; }
        public int LanguageId { get; set; }
        public int IsActived { get; set; }
    }
    public class UpdateReferencePageVM
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CustomerComment { get; set; }
        public int Rank { get; set; }
        public int LanguageId { get; set; }
        public int IsActived { get; set; }
        public List<LanguageForPanel> LanguageList { get; set; }

    }
}
