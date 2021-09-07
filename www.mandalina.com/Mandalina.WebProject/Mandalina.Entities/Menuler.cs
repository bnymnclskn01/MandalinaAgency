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
    public class Menuler : BaseEntity3
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string UrlPath { get; set; }

        public bool IsFooter { get; set; }

        public bool IsUnderFooter { get; set; }

        public bool IsSmallFooter { get; set; }

        public int Rank { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Languages Language { get; set; }
        public int PropertyId { get; set; }//1 ise ürün 2 ise hizmet 3 ise Blog 4 ise projedir.
    }
}
