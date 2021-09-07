using Mandalina.BLL.Language;
using Mandalina.Core.ViewModel.EntityVM.Work;
using Mandalina.Core.ViewModelForPanel.PanelPage.WorkPage.WorkAddPage;
using Mandalina.Core.ViewModelForPanel.PanelPage.WorkPage.WorkUpdatePage;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.WorkManager
{
    public class WorkManager
    {
        #region Helper
        public string GetWorkName(int Id)
        {
            Repository<Work> repoWork = new Repository<Work>();
            return repoWork.GetById(x => x.Id == Id).Name;
        }
        #endregion

        /// <summary>
        /// Hizmetler sayfası için listelenen işler
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        
        public List<WorkListVM> WorkList(int LanguageId,int serviceId)
        {
            Repository<Work> repoWrok = new Repository<Work>();
            var workList = repoWrok.QGetBy(x =>x.IsActiveted == true && x.IsDeleted == false && x.ServiceId == serviceId).OrderBy(x => x.Rank).Select(x => new WorkListVM { Content = x.Content, Name = x.Name, Rank = x.Rank, ServiceId = x.ServiceId }).ToList();
            return workList;
        }
        public string GetServiceName(int ServiceId)
        {
            Repository<Service> Service = new Repository<Service>();

            return Service.GetById(x => x.Id == ServiceId).serviceTitle;
        }
        public string GetServiceSlug(int ServiceId)
        {
            Repository<Service> Service = new Repository<Service>();

            return Service.GetById(x => x.Id == ServiceId).Slug;
        }
        public WorkUpdateVM GetWorkDetails(int Id)
        {
            Repository<Work> repoWork = new Repository<Work>();
            var model = repoWork.GetById(x => x.Id == Id);
            WorkUpdateVM workObj = new WorkUpdateVM
            {
                ServiceId = model.ServiceId,
                Content = model.Content,
                Id = model.Id,
                Name=model.Name,
                Rank=model.Rank
            };
            return workObj;
        }
        public int CreateWork(WorkAddVM model, string imageUrl)
        {
            Repository<Work> repoWork = new Repository<Work>();
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);
            Work work = new Work();
            work.Content = model.Content;
            work.Name = model.Name;
            work.Rank = model.Rank;
            work.ServiceId = model.ServiceId;
            if (model.IsActiveted == 1)
                work.IsActiveted = true;
            else
                work.IsActiveted = false;
            work.IsDeleted = false;
            int result = repoWork.Add(work);
            return result;
        }
        public WorkUpdateVM GetWorkUpdate(int Id)
        {
            Repository<Work> repoWork = new Repository<Work>();
            var orgWork = repoWork.GetByIdAsNotTracking(x => x.Id == Id && x.IsDeleted == false);
            if (orgWork == null)
                return null;
            else
            {
                WorkUpdateVM workObj = new WorkUpdateVM();
                workObj.Id = orgWork.Id;
                if (orgWork.IsActiveted == true)
                    workObj.IsActiveted = 1;
                else
                    workObj.IsActiveted = 0;
                workObj.Content = orgWork.Content;
                workObj.Name = orgWork.Name;
                workObj.Rank = orgWork.Rank;
                workObj.ServiceId = orgWork.ServiceId;
                return workObj;
            }
        }
        public int UpdateWork(WorkUpdateVM model, string imageUrl)
        {
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);
            Repository<Work> repoWork = new Repository<Work>();
            var workInDb = repoWork.GetById(x => x.Id == model.Id && x.IsDeleted == false);
            if (workInDb == null)
                return 0;
            else
            {
                if (model.IsActiveted == 1)
                    workInDb.IsActiveted = true;
                else
                    workInDb.IsActiveted = false;
                workInDb.Content = model.Content;
                workInDb.Id = model.Id;
                workInDb.IsDeleted = false;
                workInDb.Name = model.Name;
                workInDb.Rank = model.Rank;
                workInDb.ServiceId = model.ServiceId;
                int result = repoWork.Update(workInDb);
                return result;
            }
        }
        public int DeleteWork(int Id)
        {
            Repository<Work> repoWork = new Repository<Work>();
            var workInDb = repoWork.GetById(x => x.Id == Id && x.IsDeleted == false);
            workInDb.IsDeleted = true;
            var result = repoWork.Update(workInDb);
            return result;
        }
    }
}
