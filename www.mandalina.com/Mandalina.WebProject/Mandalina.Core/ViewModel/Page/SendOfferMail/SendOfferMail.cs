using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page.SendOfferMail
{
    public class SendOfferMail
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Giriniz")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Lütfen Konu Giriniz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Lütfen Mesajınızı Giriniz")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Lütfen Emailinizi Giriniz")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }

        public int LanguageId { get; set; }
    }
}
