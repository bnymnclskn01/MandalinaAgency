using Mandalina.Core.ViewModel.EntityVM.Slider;
using Mandalina.Core.ViewModelForPanel.PanelPage.SliderPage;
using Mandalina.DAL;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.Slider
{
    public class SliderManager
    {

        public List<MainSliderVM> MainSliderList(int LanguageId)
        {
            DataBaseContext db = new DataBaseContext();
            var list = (from a in db.Slider.ToList()
                        where a.IsActiveted == true && a.IsDeleted == false && a.LanguageId == LanguageId
                        select new MainSliderVM
                        {
                            Slogans = a.Slogans,
                            Content = a.Content,
                            Title = a.Title,
                            SliderImage = (from b in db.SliderImage.ToList()
                                           where a.Id == b.SliderId && b.IsActivited == true
                                           orderby b.Rank ascending
                                           select new SliderImageVm
                                           {
                                               ImageUrl = b.ImageUrl
                                           }).ToList()
                        }).ToList();


            return list;
        }
        #region Panel Tarafı 

        public List<SliderListPageVM> SliderPageList()
        {

            Repository<Sliders> repoSlider = new Repository<Sliders>();
            var sliderList = repoSlider.QGetByTracking(x => x.IsDeleted == false, "Language").OrderBy(x => x.Rank).Select(x => new SliderListPageVM { Rank = x.Rank, Content = x.Content, ImageUrl = x.ImageUrl, Slogans = x.Slogans, Title = x.Title, Id = x.Id, LanguageName = x.Language.Name, IsActiveted = x.IsActiveted }).ToList();

            if (sliderList != null)
            {
                return sliderList;
            }
            else
            {
                return null;
            }


        }
        public int AddSlider(AddSliderPageVM model, string imageUrl)
        {
            Repository<Sliders> repoSlider = new Repository<Sliders>();
            Sliders slider = new Sliders();
            slider.ImageUrl = imageUrl;
            slider.Content = model.Content;
            slider.LanguageId = model.LanguageId;
            slider.Slogans = model.Slogans;
            slider.Title = model.Title;
            slider.Rank = model.Rank;
            if (model.IsActiveted == 1)
            {
                slider.IsActiveted = true;
            }
            else
            {
                slider.IsActiveted = false;
            }
            int result = repoSlider.Add(slider);
            if (result > 0)
            {
                return result;
            }
            else
            {
                return 0;
            }



        }
        public UpdateSliderPageVM GetSliderForUpdate(int id)
        {
            UpdateSliderPageVM model = new UpdateSliderPageVM();
            Repository<Sliders> repoSlider = new Repository<Sliders>();
            var slider = repoSlider.GetByIdAsNotTracking(x => x.Id == id);
            if (slider != null)
            {
                model.Id = slider.Id;
                model.Content = slider.Content;
                model.ImageUrl = slider.ImageUrl;
                if (slider.IsActiveted == true)
                {
                    model.IsActiveted = 1;
                }
                else
                {
                    model.IsActiveted = 0;
                }
                model.LanguageId = slider.LanguageId;
                model.Rank = slider.Rank;
                model.Slogans = slider.Slogans;
                model.Title = slider.Title;
                return model;
            }
            else
            {
                return null;
            }
        }
        public int UpdateSlider(UpdateSliderPageVM model, string imageUrl)
        {
            Repository<Sliders> repoSlider = new Repository<Sliders>();
            var slider = repoSlider.GetById(x => x.Id == model.Id);
            if (slider != null)
            {
                slider.Content = model.Content;
                if (imageUrl != "")
                {
                    slider.ImageUrl = imageUrl;
                }

                if (model.IsActiveted == 1)
                {
                    slider.IsActiveted = true;
                }
                else
                {
                    slider.IsActiveted = false;
                }
                slider.LanguageId = model.LanguageId;
                slider.Rank = model.Rank;
                slider.Slogans = model.Slogans;
                slider.Title = model.Title;
                int result = repoSlider.Update(slider);
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }


        }

        public int DeleteSlider(int id)
        {
            Repository<Sliders> repoSlider = new Repository<Sliders>();
            var slider = repoSlider.GetById(x => x.Id == id);
            slider.IsDeleted = true;
            int result = repoSlider.Update(slider);
            if (result > 0)
            {
                return result;
            }
            else
            {
                return 0;
            }


        }
        public string GetSliderName(int id)
        {
            Repository<Sliders> Slider = new Repository<Sliders>();

            return Slider.GetById(x => x.IsDeleted == false && x.Id == id).Title;
        }
        public List<SliderImageVM> SliderImageListForPanel(int id)
        {
            Repository<SliderImage> repoSliderImage = new Repository<SliderImage>();
            var SliderList = repoSliderImage.QGetByTracking(x => x.SliderId == id ).OrderBy(x => x.Rank).Select(x => new SliderImageVM { Id = x.Id, ImageUrl = x.ImageUrl, Name = x.Name, Rank = x.Rank, IsActiveted = x.IsActivited }).ToList();
            if (SliderList != null)
            {
                return SliderList;
            }
            else
            {
                return null;
            }


        }

        public int CreateImageSlider(SliderImageVM model, string imageUrl)
        {
            Repository<SliderImage> repoSliderImage = new Repository<SliderImage>();
            SliderImage sliderImage = new SliderImage();

            sliderImage.SliderId = model.SliderId;
            sliderImage.Name = model.Name;
            sliderImage.ImageUrl = imageUrl;
            sliderImage.Rank = model.Rank;

            if (model.IsActiveted == true)
            {
                sliderImage.IsActivited = true;
            }
            else
            {
                sliderImage.IsActivited = false;
            }

            int result = repoSliderImage.Add(sliderImage);
            if (result > 0)
            {
                return result;
            }
            else
            {
                return 0;
            }


        }

        public SliderImageVM GetSliderImage(int id)
        {
            Repository<SliderImage> repoSliderImage = new Repository<SliderImage>();
            var SliderImage = repoSliderImage.GetByIdAsNotTracking(x => x.Id == id);
            if (SliderImage != null)
            {
                SliderImageVM SliderImageObj = new SliderImageVM();
                SliderImageObj.Id = SliderImage.Id;
                if (SliderImage.IsActivited == true)
                {
                    SliderImageObj.IsActiveted = true;
                }
                else
                {
                    SliderImageObj.IsActiveted = false;
                }

                SliderImageObj.Name = SliderImage.Name;
                SliderImageObj.Rank = SliderImage.Rank;
                SliderImageObj.SliderId = SliderImage.SliderId;
                SliderImageObj.ImageUrl = SliderImage.ImageUrl;
                return SliderImageObj;

            }
            else
            {
                return null;
            }


        }

        public int SliderUpdate(SliderImageVM model, string imageUrl)
        {

            Repository<SliderImage> repoSlider = new Repository<SliderImage>();

            var sliderObj = repoSlider.GetById(x => model.Id == x.Id);
            if (sliderObj != null)
            {

                sliderObj.Name = model.Name;
                if (imageUrl != "")
                {
                    sliderObj.ImageUrl = imageUrl;

                }
                sliderObj.Rank = model.Rank;


                if (model.IsActiveted == true)
                {
                    sliderObj.IsActivited = true;
                }
                else
                {
                    sliderObj.IsActivited = false;
                }



                int result = repoSlider.Update(sliderObj);

                if (result > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        public int DeleteImageSlider(int id)
        {

            Repository<SliderImage> repoSliderImage = new Repository<SliderImage>();
            var sliderImage = repoSliderImage.GetById(x => x.Id == id);

            int result = repoSliderImage.Update(sliderImage);
            if (result > 0)
            {

                return sliderImage.SliderId;
            }
            else
            {
                return 0;
            }

        }

        #endregion
    }
}
