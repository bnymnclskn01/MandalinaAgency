using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.ServicePage.ServiceListPage
{
    public class ServiceListForPanel
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Rank { get; set; }
        public bool State { get; set; }
    }
}
