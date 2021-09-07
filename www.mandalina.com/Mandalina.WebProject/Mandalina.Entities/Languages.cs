using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class Languages : BaseEntity
    {
        public Languages()
        {
            this.ContactInformation = new HashSet<ContactInformation>();
            this.Slider = new HashSet<Sliders>();
            this.AboutUs = new HashSet<AboutUs>();
            this.Service = new HashSet<Service>();
            this.Category = new HashSet<Categories>();
            this.Menuler = new HashSet<Menuler>();
            this.SeoSetting = new HashSet<SeoSettings>();
            this.ConstantValue = new HashSet<ConstantValues>();
            this.VideoPlayer = new HashSet<VideoPlayer>();
        }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public virtual ICollection<Sliders> Slider { get; set; }
        public virtual ICollection<AboutUs> AboutUs { get; set; }
        public virtual ICollection<Categories> Category { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<Menuler>Menuler { get; set; }
        public virtual ICollection<SeoSettings> SeoSetting { get; set; }
        public virtual ICollection<SocialMedias> SocialMedia { get; set; }
        public virtual ICollection<ConstantValues> ConstantValue { get; set; }
        public virtual ICollection<VideoPlayer> VideoPlayer { get; set; }
    }
}
