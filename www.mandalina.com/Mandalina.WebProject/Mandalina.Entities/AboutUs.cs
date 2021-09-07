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
    public class AboutUs : BaseEntity3
    {
        [StringLength(110)]
        public string MainTitle { get; set; }

        [StringLength(110)]
        public string Title { get; set; }

        public string AboutUsContent { get; set; }

        public string VisionContent { get; set; }

        public string MissionContent { get; set; }
        
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public virtual Languages Language { get; set; }
    }
}
