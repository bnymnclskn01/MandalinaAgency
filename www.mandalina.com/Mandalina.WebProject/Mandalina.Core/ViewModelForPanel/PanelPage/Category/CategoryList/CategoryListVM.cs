using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryList
{
    public class CategoryListVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Note { get; set; }

        public int Rank { get; set; }

        public string Slug { get; set; }

        public string Language { get; set; }

        public int IsActivated { get; set; }

        public string RawSlug { get; set; }
    }
}
