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
    public class SocialMedias : BaseEntity3
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Link { get; set; }

        public int Rank { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public virtual Languages Language { get; set; }
    }
}
