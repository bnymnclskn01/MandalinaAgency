using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page
{
    public class ContactVMEn
    {
        [Required(ErrorMessage = "Name field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "E-mail field is required.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone field is required.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Profession field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Profession")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Company field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "City field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Subject field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public bool SubscribedToNewsletter { get; set; }

        public bool Sms { get; set; }

        public int langId { get; set; }
    }
}
