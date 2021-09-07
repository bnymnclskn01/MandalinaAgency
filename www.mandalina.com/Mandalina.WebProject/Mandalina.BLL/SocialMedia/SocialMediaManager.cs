using Mandalina.Core.ViewModel.EntityVM.SocialMedia;
using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.SocialMedia
{
    public class SocialMediaManager
    {
        public List<SocialMediaVM> SocialMediaList()
        {
            Repository<SocialMedias> socialMedias = new Repository<SocialMedias>();

            var socialMediaList = socialMedias.QGetBy(x => x.IsActiveted == true && x.IsDeleted == false).OrderBy(x => x.Rank).Select(x => new SocialMediaVM { Name = x.Name.ToLower(), Link = x.Link }).ToList();

            if (socialMediaList.Count > 0)
            {
                return socialMediaList;
            }
            else
            {
                return null;
            }

        }
    }
}
