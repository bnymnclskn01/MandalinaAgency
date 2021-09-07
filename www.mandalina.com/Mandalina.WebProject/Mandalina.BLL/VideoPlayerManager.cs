using Mandalina.Core.ViewModel.EntityVM;
using Mandalina.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL
{
    public class VideoPlayerManager
    {
        public List<MainVideoPlayerVM> MainSliderList(int LanguageId)
        {
            DataBaseContext db = new DataBaseContext();
            var list = (from a in db.VideoPlayer.ToList()
                        where a.IsActiveted == true && a.IsDeleted == false && a.LanguageId == LanguageId
                        select new MainVideoPlayerVM
                        {
                            Slogans = a.Alt,
                            Content = a.Content,
                            Title = a.Title,
                            VideoUrl = a.VideUrl
                        }).ToList();
            return list;
        }
    }
}
