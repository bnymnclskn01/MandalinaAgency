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
    public class ContactInformation : BaseEntity3
    {
        [StringLength(800)]
        public string Address { get; set; }

        [StringLength(800)]
        public string Address2 { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        public string PhoneNumber2 { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(15)]
        public string FaxNumber { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public virtual Languages Language { get; set; }
    }
}
