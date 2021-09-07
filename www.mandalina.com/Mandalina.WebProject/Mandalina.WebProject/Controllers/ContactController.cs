using Mandalina.BLL.ConstantValue;
using Mandalina.Core.ViewModel.Page;
using Mandalina.DAL;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Mandalina.WebProject.Controllers
{
    public class ContactController : BaseController
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Contact
        public ActionResult Index()
        {
            Meta();
            return View();
        }
        [HttpPost]
        [Route("iletisim")]
        public ActionResult Index(ContactForm contactForm)
        {
            Meta();
            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient("ni-trio-win.guzelhosting.com", 587);
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("info@mandalina.agency", "Mandalina@12121314");
                client.EnableSsl = true;
                client.Credentials = credentials;
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("info@mandalina.agency", "MANDALİNA AGENCY İletişim");
                    mailMessage.To.Add(new MailAddress("info@mandalina.agency", "MANDALİNA AGENCY İletişim"));
                    mailMessage.Subject = contactForm.Subject;
                    mailMessage.Body = "<h3>" + Request.Url + "<br> Yukarıda belirtilen siteden size bir mail gelmişitir.<hr></h3><p>Mail içeriği aşağıda size verilen bilgiler doğrultuusnda maili kimin gönderdiği hangi mail adresi ile gönderdi bunların hepsi site tarafında mevcut olarak bulunmaktadır.</p><hr><h5><b>Mail Gönderinin Adı Soyadı : </b></h5>" + contactForm.Name + " " + contactForm.Surname + "<hr><h5><b>Mail Gönderenin Mail Adresi : </b></h5>" + contactForm.Mail + "<hr><h5><b>Mail Gönderenin Telefon Bilgisi :  </b></h5>" + contactForm.Phone + "<hr><h5><b>Mail Gönderenin Konusu : </b></h5>" + contactForm.Subject + "<hr><h5><b>Mail Gönderen Kişinin Mesajı : </b></h5>" + contactForm.Message;
                    mailMessage.IsBodyHtml = true;
                    contactForm.CreateDate = DateTime.Now;
                    contactForm.LanguageId = 1;
                    db.ContactForm.Add(contactForm);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Mailiniz bize ulaştı en yakın zamanda size geri dönüş sağlanacaktır.";
                }
                catch
                {
                    ViewBag.Hata = "Mail gönderirken bir hata oluştu";
                }
            }
            return View(contactForm);
        }

        public ActionResult PartialContactInfromation()
        {
            return PartialView(db.ContactInformation.Where(x => x.IsActiveted == true && x.IsDeleted == false).FirstOrDefault());
        }
        public ActionResult PartialContsantValueContactTitle()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "iletisim").FirstOrDefault());
        }
        public ActionResult PartialContsantValueContactInformationTitle()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "iletisim-2").FirstOrDefault());
        }
        public ActionResult PartialContsantValueContactFormTitle()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "iletisim-3").FirstOrDefault());
        }
    }
}