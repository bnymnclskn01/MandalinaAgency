using Mandalina.Core.ViewModel.Page.ReferencePage;
using Mandalina.Core.ViewModelForPanel.PanelPage.ReferencePage;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.ReferenceManager
{
    public class ReferenceManager
    {
        Repository<References> referenceManager = new Repository<References>();
        public ReferencePageVM GetReference(int langId)
        {
            var references = referenceManager.GetById(x => x.LanguageId == langId);

            ReferencePageVM referencePage = new ReferencePageVM()
            {
                CompanyName = references.CompanyName,
                CustomerComment = references.CustomerComment,
                Rank = references.Rank,
                LogoUrl = references.LogoUrl
            };
            return referencePage;
        }
        public List<ReferencePageVM> ReferencePageList()
        {
            var referencePage = referenceManager.QGetBy(x => x.IsDeleted == false, "Language").OrderBy(x => x.Rank).Select(x => new ReferencePageVM { Id = x.Id, Rank = x.Rank, LanguageName = x.Language.Name, IsActive = x.IsActiveted, LogoUrl = x.LogoUrl, CompanyName = x.CompanyName, CustomerComment = x.CustomerComment }).ToList();
            if (referencePage != null)
            {
                return referencePage;
            }
            else
            {
                return null;
            }
        }
        public int AddReference(AddReferencePageVM model, string url)
        {

            References references = new References()
            {
                LanguageId = model.LanguageId,
                IsActiveted = true,
                CompanyName = model.CompanyName,
                CustomerComment = model.CustomerComment,
                Rank = model.Rank,
                LogoUrl = model.LogoUrl,
                IsDeleted = false,

            };

            int result = referenceManager.Add(references);

            return result;

        }
        public UpdateReferencePageVM GetReferenceUpdate(int id)
        {

            var model = referenceManager.GetByIdAsNotTracking(x => x.Id == id && x.IsDeleted == false);

            if (model == null)
                return null;
            else
            {
                UpdateReferencePageVM referenceList = new UpdateReferencePageVM()
                {
                    Id = id,
                    LanguageId = model.LanguageId,
                    IsActived = model.IsActiveted == true ? 1 : 0,
                    CompanyName = model.CompanyName,
                    CustomerComment = model.CustomerComment,
                    Rank = model.Rank,
                };

                return referenceList;
            }
        }
        public int UpdateReference(UpdateReferencePageVM model, string url)
        {

            var references = referenceManager.GetById(x => x.Id == model.Id);

            if (references == null)
                return 0;
            else
            {
                references.IsActiveted = model.IsActived == 1 ? true : false;
                references.LanguageId = model.LanguageId;
                references.CustomerComment = model.CustomerComment;
                if (url != "")
                {
                    references.LogoUrl = url;

                }
                references.Rank = model.Rank;
                references.CompanyName = model.CompanyName;
                var result = referenceManager.Update(references);
                return result;
            }
        }
        public int DeletePersonel(int id)
        {

            var references = referenceManager.GetById(x => x.Id == id);

            if (references == null)
                return 0;
            else
            {
                references.IsDeleted = true;

                var result = referenceManager.Update(references);

                return result;
            }
        }


        //UI Tarafı Fonksiyonları

        public List<ReferenceModel> ReferencesForHomeList(int langId)
        {

            var list = referenceManager.QGetByTracking(x => x.LanguageId == langId && x.IsActiveted == true && x.IsDeleted == false).OrderBy(x => x.Rank).Select(x => new ReferenceModel { CompanyName = x.CompanyName, CustomerComment = x.CustomerComment, LogoUrl = x.LogoUrl }).ToList();
            return list;
        }
        public List<ReferenceModel> ReferencesList(int langId)
        {

            var list = referenceManager.QGetByTracking(x => x.LanguageId == langId && x.IsActiveted == true && x.IsDeleted == false).OrderBy(x => x.Rank).Select(x => new ReferenceModel { CompanyName = x.CompanyName, CustomerComment = x.CustomerComment, LogoUrl = x.LogoUrl }).ToList();
            return list;
        }
    }
}
