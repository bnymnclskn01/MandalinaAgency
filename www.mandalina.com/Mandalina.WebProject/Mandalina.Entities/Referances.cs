using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class References : BaseEntity
    {
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CustomerComment { get; set; }
        public int Rank { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Languages Language { get; set; }
    }
}
