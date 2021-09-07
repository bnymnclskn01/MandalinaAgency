using Mandalina.Core.ViewModel.EntityVM.Menu;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.Menu
{
    public class MenuManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <param name="IsFooter"></param> Büyük footer menü
        /// <param name="IsUnderFooter"></param> Alt footer menü
        /// <param name="IsSmallFooter"></param> küçük footer menü
        /// Tek fonksiyonda istediğimiz gibi veriyi çağırabiliyoruz.
        /// <returns></returns>
        public List<MenuVM> MenuListForLangId(int langId, bool IsFooter, bool IsUnderFooter, bool IsSmallFooter)
        {
            Repository<Menuler> menuler = new Repository<Menuler>();
            var menuList = menuler.QGetBy(x => x.LanguageId == langId && x.IsFooter == IsFooter && x.IsDeleted == false && x.IsActiveted == true && x.IsUnderFooter == IsUnderFooter && x.IsSmallFooter == IsSmallFooter).OrderBy(x => x.Rank).Select(x => new MenuVM { Name = x.Name, UrlPath = x.UrlPath, LanguageId = (int)langId, PropertyId = x.PropertyId, Id = x.Id }).ToList();
            if (menuList.Count > 0)
            {
                return menuList;
            }
            else
            {
                return null;
            }

        }
    }
}
