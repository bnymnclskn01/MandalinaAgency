using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.Page
{
    public class ContactVM
    {
        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [DataType(DataType.Text)]
        //[StringLength(100,ErrorMessage = "Min 5 karakter ve Max 100 karakter giriniz.", MinimumLength = 5)]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        [DataType(DataType.Text)]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        //[EmailAddress(ErrorMessage ="Lütfen geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Meslek alanı boş geçilemez.")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Meslek")]
        //public string Profession { get; set; }

        //[Required(ErrorMessage = "Şirket alanı boş geçilemez.")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Şirket")]
        //public string Company { get; set; }

        //[Required(ErrorMessage = "Şehir alanı boş geçilemez.")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Şehir")]
        //public string City { get; set; }

        [Required(ErrorMessage = "Konu boş geçilemez.")]
        [DataType(DataType.Text)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş geçilemez.")]
        [DataType(DataType.Text)]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }

        public bool SubscribedToNewsletter { get; set; }

        public bool Sms { get; set; }

        public int langId { get; set; }

        public List<ConstantValueVM> ConstantValues { get; set; } //sabit değerler

        public string BreadCrumpLink { get; set; }

    }
}
