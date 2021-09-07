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
    public class ConstantValues : BaseEntity3
    {
        [StringLength(300)]
        public string Key { get; set; }


        public string Value { get; set; }

        [StringLength(150)]
        public string PageName { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }


        public virtual Languages Language { get; set; }
    }
}
