using Mandalina.BLL.Language;
using Mandalina.Core.ViewModel.EntityVM.Category;
using Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryCreate;
using Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryList;
using Mandalina.Core.ViewModelForPanel.PanelPage.Category.CategoryUpdate;
using Mandalina.DAL;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.Category
{
    public class CategoryManager
    {

        public List<CategoryVM> CategoryList(int LanguageId, int TypeId)
        {
            Repository<Categories> _repoCategory = new Repository<Categories>();

            var categoryList = _repoCategory.QGetBy(x => x.IsActiveted == true && x.IsDeleted == false && x.LanguageId == LanguageId).OrderBy(x => x.Rank).Select(x => new CategoryVM { CategorySlug = x.CategorySlug, Content = x.Content, Name = x.Name, Id = x.Id }).ToList();

            if (categoryList.Count > 0)
            {

                return categoryList;

            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Ürünler Listesi sayfasındaki kategori listesi methodu categoryname controller da gelecektir.
        /// </summary>
        /// <param name="LanguageId"></param>
        /// <param name="CategoryName"></param>
        /// <returns></returns>

        public List<CategoryVM> CategoryListForService(int LanguageId)
        {
            Repository<Categories> _repoCategory = new Repository<Categories>();

            var categoryList = _repoCategory.QGetBy(x => x.IsActiveted == true && x.IsDeleted == false && x.LanguageId == LanguageId ).OrderBy(x => x.Rank).Select(x => new CategoryVM { CategorySlug = x.CategorySlug, Name = x.Name }).ToList();

            if (categoryList.Count > 0)
            {

                return categoryList;

            }
            else
            {
                return null;
            }
        }
        public int GetCategoryId(string CategoryName, int langId)
        {
            Repository<Categories> _repoCategory = new Repository<Categories>();
            if (CategoryName == null)
            {
                return 0;

            }



            else
            {
                int catID = 0;
                Categories catInDb = _repoCategory.GetById(x => x.CategorySlug == CategoryName && x.IsDeleted == false && x.IsActiveted == true);

                if (catInDb != null)
                {
                    catID = catInDb.Id != 0 ? catInDb.Id : 0;
                }
                return catID;
            }
        }
        /// <summary>
        /// Gelen parametreye göre kategori listesini getirir.
        /// </summary>
        /// <param name="langId"></param>
        /// <returns></returns>
        public string GetCategorySlug(int id)
        {
            Repository<Categories> _repoCategory = new Repository<Categories>();
            return _repoCategory.GetById(x => x.Id == id).RawSlug.ToLower();
        }
        public string GetCategoryName(string CategorySlug)
        {
            Repository<Categories> _repoCategory = new Repository<Categories>();
            return _repoCategory.GetById(x => x.RawSlug == CategorySlug).Name;
        }

        #region Panel İçin 

        /// <summary>
        /// Kategorileri listeler
        /// </summary>
        /// <returns></returns>
        public List<CategoryListVM> CategoryListForPanel()
        {
            Repository<Categories> repoCategory = new Repository<Categories>();

            var categoryList = repoCategory.QGetBy(x => x.IsDeleted == false, "Language").Select(x => new CategoryListVM { Content = x.Content, Id = x.Id, IsActivated = x.IsActiveted == true ? 1 : 0, Language = x.Language.Name, Name = x.Name, RawSlug = x.RawSlug, Slug = x.CategorySlug }).ToList();

            return categoryList;
        }

        /// <summary>
        ///Kategori oluştur
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public int CreateCategory(CategoryCreateVM model, string imageUrl)
        {
            Repository<SeoSettings> seoSettingManager = new Repository<SeoSettings>();
            Repository<Categories> repoCategory = new Repository<Categories>();
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);

            Categories category = new Categories();

            if (model.IsActivated == 1)
                category.IsActiveted = true;
            else
                category.IsActiveted = false;

            category.LanguageId = model.LanguageId;
            category.Content = model.Content;
            category.Name = model.Name;
            category.RawSlug = model.RawSlug;
            int result = repoCategory.Add(category);
            SeoSettings seo = new SeoSettings();
            seo.Url = category.CategorySlug;
            seo.LanguageId = category.LanguageId;
            seo.Keywords = "";
            seo.Description = "";
            seo.Title = "";
            seo.PageName = category.Name;
            seo.PageCategory = "Kategori";
            int result2 = seoSettingManager.Add(seo);
            return result;

        }
        public CategoryUpdateVM GetCategoryForUpdate(int id)
        {
            Repository<Categories> repoCategory = new Repository<Categories>();

            var categoryInDb = repoCategory.GetByIdAsNotTracking(x => x.Id == id && x.IsDeleted == false);

            if (categoryInDb == null)
                return null;
            else
            {
                CategoryUpdateVM categoryUpdateVM = new CategoryUpdateVM()
                {
                    Content = categoryInDb.Content,
                    Id = categoryInDb.Id,
                    IsActivated = categoryInDb.IsActiveted == true ? 1 : 0,
                    LanguageId = categoryInDb.LanguageId,
                    Name = categoryInDb.Name,
                    RawSlug = categoryInDb.RawSlug
                };

                return categoryUpdateVM;
            }
        }

        /// <summary>
        /// Kategori güncelle
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public int CategoryUpdate(CategoryUpdateVM model, string imageUrl)
        {
            LanguageManager langManager = new LanguageManager();
            string langCode = langManager.GetLangCode(model.LanguageId);

            Repository<Categories> repoCategory = new Repository<Categories>();
            Repository<SeoSettings> seoSettingManager = new Repository<SeoSettings>();

            var categoryInDb = repoCategory.GetById(x => x.Id == model.Id && x.IsDeleted == false);
            string seoUrl = null;
            if (categoryInDb == null)
                return 0;
            else
            {
                seoUrl = categoryInDb.CategorySlug;
                categoryInDb.IsActiveted = model.IsActivated == 1 ? true : false;
                categoryInDb.LanguageId = model.LanguageId;
                categoryInDb.Name = model.Name;
                categoryInDb.RawSlug = model.RawSlug;
                categoryInDb.Content = model.Content;
                int result = repoCategory.Update(categoryInDb);
                var seo = seoSettingManager.GetById(x => x.Url == seoUrl);
                seo.Url = categoryInDb.CategorySlug;
                seo.LanguageId = categoryInDb.LanguageId;
                int result2 = seoSettingManager.Update(seo);

                return result;
            }
        }

        /// <summary>
        /// Kategori Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CategoryDelete(int id)
        {
            Repository<Categories> repoCategory = new Repository<Categories>();

            var categoryInDb = repoCategory.GetById(x => x.Id == id && x.IsDeleted == false);

            if (categoryInDb == null)
                return 0;
            else
                categoryInDb.IsDeleted = true;

            var result = repoCategory.Update(categoryInDb);

            return result;
        }

        #endregion

    }
}
