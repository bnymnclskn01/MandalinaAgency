using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.ConstantValuePage
{
    public class ConstantValueVMForService
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string HtmlValue { get; set; }

        public string PageName { get; set; }

        public int LanguageId { get; set; }

        public int IsActive { get; set; }

        public List<LanguageForPanel> LanguageList { get; set; }
    }
}
