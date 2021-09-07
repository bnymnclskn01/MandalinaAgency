using Mandalina.Core.ViewModel.Page.AboutUsPage;
using Mandalina.Core.ViewModelForPanel.PanelPage.AboutUsPage;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.AboutUsManager
{
    public class AboutUsManager
    {

        public AboutUsPageVM GetAboutUs(int langId)
        {
            Repository<AboutUs> aboutUsManager = new Repository<AboutUs>();


            var aboutUs = aboutUsManager.GetById(x => x.LanguageId == langId);
            AboutUsPageVM aboutUsPage = new AboutUsPageVM()
            {
                AboutUs = aboutUs.AboutUsContent,
                Mision = aboutUs.MissionContent,
                Vision = aboutUs.VisionContent
            };
            return aboutUsPage;
        }
        
        public List<AboutUsList> AboutUsList()
        {
            Repository<AboutUs> repoAboutUs = new Repository<AboutUs>();
            var aboutList = repoAboutUs.QGetBy(x => x.IsDeleted == false, "Language").Select(x => new AboutUsList { Id = x.Id, IsActiveted = x.IsActiveted, Language = x.Language.Name }).ToList();
            return aboutList;
        }

        public AboutUsUpdateVM GetAboutUsDetail(int id)
        {
            Repository<AboutUs> repoAboutUs = new Repository<AboutUs>();
            var model = repoAboutUs.GetById(x => x.Id == id);
            AboutUsUpdateVM aboutUsObj = new AboutUsUpdateVM
            {
                AboutUsContent = model.AboutUsContent,
                Id = model.Id,
                MissionContent = model.MissionContent,
                VisionContent = model.VisionContent
            };

            return aboutUsObj;


        }

        public int AboutUsUpdate(AboutUsUpdateVM model)
        {
            Repository<AboutUs> repoAboutUs = new Repository<AboutUs>();
            var aboutUsObj = repoAboutUs.GetById(x => x.Id == model.Id);
            aboutUsObj.AboutUsContent = model.AboutUsContent;
            aboutUsObj.VisionContent = model.VisionContent;
            aboutUsObj.MissionContent = model.MissionContent;
            int result = repoAboutUs.Update(aboutUsObj);
            if (result > 0)
            {
                return result;
            }
            else
            {
                return 0;
            }

        }

    }
}
