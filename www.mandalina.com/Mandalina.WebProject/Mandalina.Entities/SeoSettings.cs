using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class SeoSettings : BaseEntity
    {
        public string PageName { get; set; }
        public string PageCategory { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Languages Language { get; set; }
    }
}
