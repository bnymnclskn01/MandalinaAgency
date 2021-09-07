using Mandalina.BLL.Language;
using Mandalina.Core.ViewModel.EntityVM.ConstantValue;
using Mandalina.Core.ViewModelForPanel.PanelPage.ConstantValuePage;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.ConstantValue
{
    public class ConstantValueManager
    {
        public List<ConstantValueVM> ConstantValueGetByPageName(string pageName, int langId)
        {
            Repository<ConstantValues> constantValueManager = new Repository<ConstantValues>();

            var constantList = constantValueManager.QGetBy(x => x.LanguageId == langId && x.PageName.ToLower() == pageName.ToLower() && x.IsActiveted == true && x.IsDeleted == false).Select(x => new ConstantValueVM { Key = x.Key, Value = x.Value }).ToList();

            if (constantList.Count > 0)
            {
                return constantList;
            }
            else
            {
                return null;
            }
        }
        public List<ConstantValueListForService> ConstantValueListForPanel()
        {
            Repository<ConstantValues> repoConstantValue = new Repository<ConstantValues>();

            return repoConstantValue.QGetBy(x => x.IsDeleted == false, "Language").OrderBy(x => x.PageName).Select(x => new ConstantValueListForService { Id = x.Id, IsActive = x.IsActiveted == true ? 1 : 0, Key = x.Key, LanguageName = x.Language.Name, PageName = x.PageName, Value = x.Value }).ToList();
        }
        public ConstantValueVMForService GetConstantValueForPanel(int? id)
        {
            LanguageManager languageManager = new LanguageManager();
            var languageList = languageManager.GetLanguageList();

            if (id == null)
            {
                ConstantValueVMForService model = new ConstantValueVMForService()
                {
                    LanguageId = -1,
                    IsActive = 1,
                    LanguageList = languageList
                };

                return model;
            }

            else
            {
                Repository<ConstantValues> repoConstantValue = new Repository<ConstantValues>();

                var resultInDb = repoConstantValue.GetByIdAsNotTracking(x => x.Id == id);

                if (resultInDb == null)
                    return null;
                else
                {
                    ConstantValueVMForService constantValueVMForPanel = new ConstantValueVMForService()
                    {
                        Id = resultInDb.Id,
                        IsActive = resultInDb.IsActiveted == true ? 1 : 0,
                        Key = resultInDb.Key,
                        PageName = resultInDb.PageName,
                        Value = resultInDb.Value.Contains("</") ? "" : resultInDb.Value,
                        LanguageId = resultInDb.LanguageId,
                        LanguageList = languageList,
                        HtmlValue = resultInDb.Value.Contains("</") ? resultInDb.Value : ""
                    };

                    return constantValueVMForPanel;
                }
            }
        }

        public int ConstantValueSave(ConstantValueVMForService model)
        {
            Repository<ConstantValues> repoConstantValue = new Repository<ConstantValues>();
            LanguageManager languageManager = new LanguageManager();
            string langCode = languageManager.GetLangCode(model.LanguageId);

            if (model.Id == 0)
            {
                ConstantValues ConstantValue = new ConstantValues()
                {

                    IsActiveted = model.IsActive == 1 ? true : false,
                    LanguageId = model.LanguageId,
                    Key = model.Key,
                    PageName = model.PageName,
                };


                if (!String.IsNullOrEmpty(model.Value))
                {
                    ConstantValue.Value = model.Value;
                }
                else
                {
                    ConstantValue.Value = model.HtmlValue;
                }


                return repoConstantValue.Add(ConstantValue);
            }

            else
            {
                var resultInDb = repoConstantValue.GetById(x => x.Id == model.Id);

                if (resultInDb == null)
                    return 0;
                else
                {
                    resultInDb.IsActiveted = model.IsActive == 1 ? true : false;
                    resultInDb.LanguageId = model.LanguageId;
                    resultInDb.Key = model.Key;
                    resultInDb.PageName = model.PageName;

                    if (!String.IsNullOrEmpty(model.Value))
                    {
                        resultInDb.Value = model.Value;
                    }
                    else
                    {
                        resultInDb.Value = model.HtmlValue;
                    }

                    return repoConstantValue.Update(resultInDb);
                }
            }
        }

        public int ConstantValueDelete(int id)
        {
            Repository<ConstantValues> repoConstantValue = new Repository<ConstantValues>();

            var resultInDb = repoConstantValue.GetById(x => x.Id == id);

            if (resultInDb == null)
                return 0;
            else
            {
                resultInDb.IsDeleted = true;

                return repoConstantValue.Update(resultInDb);
            }
        }
    }
}
