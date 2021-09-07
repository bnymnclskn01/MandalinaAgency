using Mandalina.Core.ViewModelForPanel.PanelPage.Seo;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.Seo
{
    public class SeoManager
    {
        Repository<SeoSettings> repoSeoSettings = new Repository<SeoSettings>();

        public SeoSettings GetSeoSettings(string url)
        {

            var seo = repoSeoSettings.GetByIdAsNotTracking(x => x.Url == url && x.IsActiveted == true && x.IsDeleted == false);
            if (seo != null)
            {
                return seo;
            }
            else
            {
                return null;
            }

        }
        public SeoSettings GetSeoSettings(string url, int langId)
        {

            var seo = repoSeoSettings.GetByIdAsNotTracking(x => x.Url == url && x.LanguageId == langId);
            if (seo != null)
            {
                return seo;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Seo Ayarları Listeler.
        /// </summary>
        /// <returns></returns>
        public List<SeoListForPanel> SeoListForPanel()
        {
            return repoSeoSettings.QGetByTracking(x => x.IsDeleted == false, "Language").Select(x => new SeoListForPanel { Id = x.Id, Title = x.Title, Description = x.Description, Slug = x.Url, LanguageName = x.Language.Name, IsActivated = x.IsActiveted == true ? 1 : 0 }).OrderByDescending(x => x.Id).ToList();
        }


        public int AddSeo(SeoSaveForPanel model)
        {
            SeoSettings seo = new SeoSettings()
            {
                Description = model.Description,
                IsActiveted = model.IsActivated == 1 ? true : false,
                Keywords = model.Keywords,
                LanguageId = model.LanguageId,
                PageCategory = model.PageCategory,
                PageName = model.PageName,
                Title = model.Title,
                CreateDate = DateTime.Now,
                Url = model.Url,
                UpdateDate = DateTime.Now,

            };

            int result = repoSeoSettings.Add(seo);

            return result;
        }
        /// <summary>
        /// Güncellemek için seo ayarları kaydını getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeoUpdateForPanel GetSeoUpdateForPanel(int id)
        {
            var resultInDb = repoSeoSettings.GetByIdAsNotTracking(x => x.Id == id);

            if (resultInDb == null)
                return null;
            else
            {
                SeoUpdateForPanel seoUpdateForPanel = new SeoUpdateForPanel()
                {
                    Description = resultInDb.Description,
                    Keywords = resultInDb.Keywords,
                    LanguageId = resultInDb.LanguageId,
                    PageCategory = resultInDb.PageCategory,
                    PageName = resultInDb.PageName,
                    Title = resultInDb.Title,
                    Url = resultInDb.Url,
                    Id = resultInDb.Id,
                    IsActivated = resultInDb.IsActiveted == true ? 1 : 0
                };

                return seoUpdateForPanel;
            }
        }



        /// <summary>
        /// Seo Ayarı Günceller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SeoUpdateForPanel(SeoUpdateForPanel model)
        {
            var resultInDb = repoSeoSettings.GetById(x => x.Id == model.Id);

            if (resultInDb == null)
                return 0;
            else
            {
                resultInDb.Description = model.Description;
                resultInDb.IsActiveted = model.IsActivated == 1 ? true : false;
                resultInDb.Keywords = model.Keywords;
                resultInDb.LanguageId = model.LanguageId;
                resultInDb.PageCategory = model.PageCategory;
                resultInDb.PageName = model.PageName;
                resultInDb.Title = model.Title;
                resultInDb.Url = model.Url;

                return repoSeoSettings.Update(resultInDb);
            }
        }

        public int DeleteSeo(int id)
        {
            var seoSettings = repoSeoSettings.GetById(x => x.Id == id);

            if (seoSettings == null)
                return 0;
            else
            {
                seoSettings.IsDeleted = true;

                var result = repoSeoSettings.Update(seoSettings);

                return result;
            }
        }

    }
}
