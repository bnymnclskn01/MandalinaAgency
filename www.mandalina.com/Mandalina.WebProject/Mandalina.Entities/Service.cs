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
    public class Service : BaseEntity3
    {
        public Service()
        {
            this.Work = new HashSet<Work>();
        }

        [StringLength(110)]
        public string serviceTitle { get; set; }
        public string serviceTitle2 { get; set; }
        public string serviceCompany { get; set; }
        public string serviceContent { get; set; }
        public string serviceContent2 { get; set; }
        public string serviceContent3 { get; set; }
        public string serviceContent4 { get; set; }
        [StringLength(300)]
        public string ImageUrl { get; set; }

        public string Slug { get; set; }

        public string RawSlug { get; set; }

        public int Rank { get; set; }

        public bool IsMainActive { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Languages Language { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }

        public virtual ICollection<Work> Work { get; set; }
    }
}
