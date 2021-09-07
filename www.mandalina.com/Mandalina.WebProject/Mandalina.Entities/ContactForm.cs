using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandalina.Entities
{
    public class ContactForm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Surname { get; set; }

        [StringLength(150)]
        public string Mail { get; set; }

        [StringLength(150)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [StringLength(100)]
        public string City { get; set; }


        public string Subject { get; set; }

        public string Message { get; set; }

        public int LanguageId { get; set; }
        public Languages Language { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
