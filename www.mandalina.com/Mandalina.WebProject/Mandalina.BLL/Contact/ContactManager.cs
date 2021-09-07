using Mandalina.BLL.MailHelper;
using Mandalina.Core.ViewModel.EntityVM.ContactInformation;
using Mandalina.Core.ViewModel.Page;
using Mandalina.Core.ViewModel.Page.SendOfferMail;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.Contact
{
    public class ContactManager
    {
        public ContactInformationVM GetContactInformation(int langId)
        {
            ContactInformationVM contactInformationVM = new ContactInformationVM();
            Repository<ContactInformation> contactInformation = new Repository<ContactInformation>();

            var _contactInformation = contactInformation.GetById(x => x.LanguageId == langId && x.IsDeleted == false);

            if (_contactInformation != null)
            {
                contactInformationVM.Address = _contactInformation.Address;
                contactInformationVM.Mail = _contactInformation.Mail;
                contactInformationVM.PhoneNumber = _contactInformation.PhoneNumber;
                contactInformationVM.PhoneNumber2 = _contactInformation.PhoneNumber2;
                return contactInformationVM;
            }
            else
            {
                return null;
            }

        }

        public bool ContactPost(ContactVM model, ContactVMEn modelEn)
        {
            Repository<ContactForm> repoContactForm = new Repository<ContactForm>();
            MailSendingManager mailSendingManager = new MailSendingManager();

            ContactForm contactForm = new ContactForm();

            if (model != null)
            {
                contactForm.LanguageId = model.langId;
                contactForm.Mail = model.Email;
                contactForm.Message = model.Message;
                contactForm.Name = model.Name;
                contactForm.Phone = model.Phone;
                contactForm.Subject = model.Subject;
                contactForm.Surname = model.Surname;
                contactForm.CreateDate = DateTime.Now;

                var result = repoContactForm.Add(contactForm);

                if (result > 0)
                {
                    //mail atılacak
                    string body = "<p>İsim : " + model.Name + "</p><p>Soyisim : " + model.Surname + "</p><p>Telefon : " + model.Phone + "</p><p>E-Posta : " + model.Email + "</p><p>Mesaj : " + model.Message + "</p>";
                    var mailResult = mailSendingManager.SendMail("bulent.demirhan@demircode.com", model.Subject, body);


                    return true;
                }

                else
                    return false;
            }

            if (modelEn != null)
            {
                contactForm.Job = modelEn.Profession;
                contactForm.LanguageId = modelEn.langId;
                contactForm.Mail = modelEn.Email;
                contactForm.Message = modelEn.Message;
                contactForm.Surname = modelEn.Surname;
                contactForm.Name = modelEn.Name;
                contactForm.Phone = modelEn.Phone;
                contactForm.Subject = modelEn.Subject;
                contactForm.City = modelEn.City;
                contactForm.CreateDate = DateTime.Now;
                var result = repoContactForm.Add(contactForm);

                if (result > 0)
                {
                    //mail atılacak
                    //var mailResult = mailSendingManager.SendMail("izobis_info@izocam.com.tr", modelEn.Subject, modelEn.Message);


                    return true;
                }

                else
                    return true;
            }

            else
                return false;

        }

        public bool OfferPost(SendOfferMail model, ContactVMEn modelEn)
        {
            Repository<SendAndOffer> repoSenAndForm = new Repository<SendAndOffer>();
            MailSendingManager mailSendingManager = new MailSendingManager();

            SendAndOffer sendAndOffer = new SendAndOffer();

            if (model != null)
            {

                sendAndOffer.Message = model.Message;
                sendAndOffer.Name = model.Name;
                sendAndOffer.Phone = model.Phone;
                sendAndOffer.Subject = model.Subject;
                sendAndOffer.Surname = model.Surname;
                sendAndOffer.Email = model.EMail;
                sendAndOffer.CreateDate = DateTime.Now;
                sendAndOffer.UpdateDate = DateTime.Now;
                sendAndOffer.LanguageId = model.LanguageId;
                int result = repoSenAndForm.Add(sendAndOffer);


                if (result > 0)
                {
                    string body = "<p>İsim : " + model.Name + "</p><p>Soyisim : " + model.Surname + "</p><p>Telefon : " + model.Phone + "</p><p>E-Posta : " + model.EMail + "</p><p>Mesaj : " + model.Message + "</p>";
                    var mailResult = mailSendingManager.SendMail("bulent.demirhan@demircode.com", model.Subject, body);

                    return true;
                }

                else
                    return false;
            }
            else
                return false;

        }


    }
}
