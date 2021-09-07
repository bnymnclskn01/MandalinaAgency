using Mandalina.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandalina.Core.ViewModelForPanel.EntityVMForPanel.LanguageForPanel;
using Mandalina.Core.ViewModel.EntityVM.Language;
using Mandalina.Entities;

namespace Mandalina.BLL.Language
{
    public class LanguageManager
    {
        public int GetLanguageId(string LangCode)
        {
            Repository<Languages> _languageManager = new Repository<Languages>();

            int id = _languageManager.GetById(x => x.Code.ToLower() == LangCode.ToLower()).Id;
            return id;
        }
        public List<LanguageVM> LanguageList()
        {
            Repository<Languages> languageManager = new Repository<Languages>();
            var languageList = languageManager.QGetAll().Select(x => new LanguageVM { Code = x.Code, Name = x.Name }).ToList();
            if (languageList.Count > 0)
            {
                return languageList;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// panel tarafında ürünlere,projelere vs veri eklenirken kullanılacak liste
        /// </summary>
        /// <returns></returns>

        public List<LanguageForPanel> GetLanguageList()
        {
            Repository<Languages> languageManager = new Repository<Languages>();
            var languageList = languageManager.QGetBy(x => x.IsDeleted == false && x.IsActiveted == true).Select(x => new LanguageForPanel { Id = x.Id, LangName = x.Name }).ToList();
            if (languageList.Count > 0)
            {
                return languageList;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Dil kodunu getirir 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLangCode(int id)
        {
            Repository<Languages> languageManager = new Repository<Languages>();
            return languageManager.GetById(x => x.Id == id).Code.ToLower();

        }

    }
}
