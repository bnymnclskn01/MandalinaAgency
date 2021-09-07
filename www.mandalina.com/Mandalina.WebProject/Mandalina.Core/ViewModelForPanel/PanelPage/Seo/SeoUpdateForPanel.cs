using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.Seo
{
    public class SeoUpdateForPanel
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string PageName { get; set; }

        public string PageCategory { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Url { get; set; }

        public int IsActivated { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }

    }
    public class SeoSaveForPanel
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string PageName { get; set; }

        public string PageCategory { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Url { get; set; }

        public int IsActivated { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }

    }
}
