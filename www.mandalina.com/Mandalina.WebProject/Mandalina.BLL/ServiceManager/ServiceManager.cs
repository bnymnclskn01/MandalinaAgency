using Mandalina.BLL.Language;
using Mandalina.Core.Helper;
using Mandalina.Core.ViewModel.EntityVM.Service;
using Mandalina.Core.ViewModelForPanel.PanelPage.ServicePage.ServiceAddPage;
using Mandalina.Core.ViewModelForPanel.PanelPage.ServicePage.ServiceUpdateVM;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.ServiceManager
{
    public class ServiceManager
    {
        #region Helper
        public string GetServiceName(int Id)
        {
            Repository<Service> repoService = new Repository<Service>();
            return repoService.GetById(x => x.Id == Id).serviceTitle;
        }
        #endregion

        public List<ServiceForHome> ServiceForHomeList(int LangId)
        {
            Repository<Service> repoService = new Repository<Service>();
            var serviceList = repoService.QGetBy(x => x.LanguageId == LangId && x.IsDeleted == false && x.IsActiveted == true).OrderBy(x => x.Rank).Select(x => new ServiceForHome { Title = x.serviceTitle, Content = x.serviceContent, ImageUrl = x.ImageUrl, Slug = x.Slug, CategoryId = x.CategoryId }).ToList();
            if (serviceList.Count > 0)
            {
                return serviceList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Hizmetler sayfası için listelenen işler
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>

        public List<ServiceListVM> ServiceList(int LanguageId,int catId)
        {
            Repository<Service> repoService = new Repository<Service>();
            var serviceList = repoService.QGetBy(x => x.LanguageId == LanguageId && x.IsActiveted == true && x.IsDeleted == false && x.CategoryId == catId).OrderBy(x => x.Rank).Select(x => new ServiceListVM { Content = x.serviceContent, ImageUrl = x.ImageUrl,CategoryId=x.CategoryId, Name = x.serviceTitle, Slug = x.Slug}).Take(16).ToList();
            return serviceList;
        }

        public List<ServiceListVM> ServiceList2(int LanguageId, int catId)
        {
            Repository<Service> repoService = new Repository<Service>();
            var serviceList = repoService.QGetBy(x => x.LanguageId == LanguageId && x.IsActiveted == true && x.IsDeleted == false && x.CategoryId == catId).OrderBy(x => x.Rank).Select(x => new ServiceListVM { Content = x.serviceContent, ImageUrl = x.ImageUrl, CategoryId = x.CategoryId, Name = x.serviceTitle, Slug = x.Slug }).ToList();
            return serviceList;
        }

        public string GetCategoryName(int categoryId)
        {
            Repository<Categories> Category = new Repository<Categories>();

            return Category.GetById(x => x.Id == categoryId).Name;
        }
        public string GetCategorySlug(int categoryId)
        {
            Repository<Categories> Category = new Repository<Categories>();

            return Category.GetById(x => x.Id == categoryId).CategorySlug;
        }
        public ServiceDetail ServiceDetails (string SeoLink)
        {
            Repository<Service> repoService = new Repository<Service>();
            Repository<Work> repoWork = new Repository<Work>();
            var serviceDetailsInDb = repoService.GetByIdAsNotTracking(x => x.Slug == SeoLink);
            if (serviceDetailsInDb == null)
                return null;
            else
            {
                ServiceDetail serviceDetail = new ServiceDetail()
                {
                    Name = serviceDetailsInDb.serviceTitle,
                    Slug = serviceDetailsInDb.Slug,
                    Content= serviceDetailsInDb.serviceContent,
                    CatId=serviceDetailsInDb.CategoryId,
                    ImageUrl=serviceDetailsInDb.ImageUrl,
                };
                foreach (var item in serviceDetail.WorkListVM)
                {
                    item.Name = serviceDetail.WorkListVM.FirstOrDefault().Name;
                    item.Content = serviceDetail.WorkListVM.FirstOrDefault().Content;
                    item.ImageUrl = serviceDetail.WorkListVM.FirstOrDefault().ImageUrl;
                    item.Rank = serviceDetail.WorkListVM.FirstOrDefault().Rank;
                }
                return serviceDetail;
            }
        }
        public int CreateService(ServiceAddVM model, string imageUrl)
        {
            Repository<SeoSettings> seoSettingManager = new Repository<SeoSettings>();
            Repository<Service> repoService = new Repository<Service>();
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);
            Service service = new Service();
            service.LanguageId = model.LanguageId;
            service.serviceTitle = model.Title;
            service.serviceContent = model.Content;
            service.CategoryId = model.CategoryId;
            service.Rank = model.Rank;
            service.RawSlug = StringHelper.StringReplacer(model.Slug);
            if (model.LanguageId == 1)
                service.Slug = "/" + "isler/" + StringHelper.StringReplacer(model.Slug);
            else
                service.Slug = "/" + "work/" + StringHelper.StringReplacer(model.Slug);
            service.ImageUrl = model.ImageUrl;
            if (model.IsActiveted == 1)
                service.IsActiveted = true;
            else
                service.IsActiveted = false;
            service.IsDeleted = false;
            int result = repoService.Add(service);
            if (result > 0)
            {
                SeoSettings seo = new SeoSettings();
                seo.Keywords = "";
                seo.Description = "";
                seo.Title = "";
                seo.Url = service.Slug;
                seo.LanguageId = service.LanguageId;
                seo.PageName = service.serviceTitle;
                seo.PageCategory = "Proje";
                int seoResult = seoSettingManager.Add(seo);
                return service.Id;
            }
            else
                return 0;
        }
        public ServiceUpdateVM GetServiceUpdate(int Id)
        {
            Repository<Service> repoService = new Repository<Service>();
            var orgService = repoService.GetByIdAsNotTracking(x => x.Id == Id && x.IsDeleted == false);
            if (orgService == null)
                return null;
            else
            {
                ServiceUpdateVM serviceObj = new ServiceUpdateVM();
                serviceObj.Id = orgService.Id;
                if (orgService.IsActiveted == true)
                    serviceObj.IsActiveted = 1;
                else
                    serviceObj.IsActiveted = 0;
                serviceObj.LanguageId = orgService.LanguageId;
                serviceObj.Title = orgService.serviceTitle;
                serviceObj.Rank = orgService.Rank;
                serviceObj.RawSlug = orgService.RawSlug;
                serviceObj.Content = orgService.serviceContent;
                serviceObj.CategoryId = orgService.CategoryId;
                serviceObj.ImageUrl = orgService.ImageUrl;
                serviceObj.Slug = orgService.Slug;
                return serviceObj;
            }
        }
        public int UpdateService(ServiceUpdateVM model, string imageUrl)
        {
            Repository<SeoSettings> seoSettingManager = new Repository<SeoSettings>();
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);
            Repository<Service> repoService = new Repository<Service>();
            var serviceInDb = repoService.GetById(x => x.Id == model.Id && x.IsDeleted == false);
            if (serviceInDb == null)
                return 0;
            else
            {
                string seoUrl = serviceInDb.Slug;
                if (model.IsActiveted == 1)
                    serviceInDb.IsActiveted = true;
                else
                    serviceInDb.IsActiveted = false;
                serviceInDb.LanguageId = model.LanguageId;
                serviceInDb.serviceContent = model.Content;
                serviceInDb.serviceTitle = model.Title;
                if (imageUrl != "")
                {
                    serviceInDb.ImageUrl = imageUrl;
                }
                serviceInDb.CategoryId = model.CategoryId;
                serviceInDb.Rank = model.Rank;
                if (model.LanguageId == 1)
                    serviceInDb.Slug = "/" + "isler/" + StringHelper.StringReplacer(model.Slug);
                else if (model.LanguageId == 2)
                    serviceInDb.Slug = "/" + "work/" + StringHelper.StringReplacer(model.Slug);
                int result = repoService.Update(serviceInDb);
                if (result > 0)
                {
                    var seo = seoSettingManager.GetById(x => x.Url == seoUrl);
                    seo.LanguageId = serviceInDb.LanguageId;
                    seo.PageName = model.Title;
                    seo.Url = serviceInDb.Slug;
                    int seoResult = seoSettingManager.Update(seo);
                    return result;
                }
                return result;
            }
        }
        public int DeleteService(int Id)
        {
            Repository<Service> repoService = new Repository<Service>();
            var serviceInDb = repoService.GetById(x => x.Id == Id && x.IsDeleted == false);
            serviceInDb.IsDeleted = true;
            var result = repoService.Update(serviceInDb);
            return result;
        }
    }
}
