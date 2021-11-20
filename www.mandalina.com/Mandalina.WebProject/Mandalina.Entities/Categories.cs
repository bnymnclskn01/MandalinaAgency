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
    public class Categories : BaseEntity3
    {

        public Categories()
        {
            this.Service = new HashSet<Service>();
            this.ServiceCategories = new HashSet<ServiceCategory>();
        }

        [StringLength(110)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Note { get; set; }
        
        [StringLength(5000)]
        public string Content { get; set; }

        [StringLength(75)]
        public string Rank { get; set; }

        [StringLength(100)]
        public string CategorySlug { get; set; }

        [StringLength(100)]
        public string RawSlug { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Languages Language { get; set; }

        public virtual ICollection<Service> Service { get; set; }

        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
    }
}
