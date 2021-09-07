using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class Sliders : BaseEntity
    {
        public Sliders()
        {
            this.SliderImage = new HashSet<SliderImage>();
        }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }

        [StringLength(300)]
        public string Alt { get; set; }
        [StringLength(300)]
        public string Slogans { get; set; }

        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public int Rank { get; set; }
        public virtual Languages Language { get; set; }
        public virtual ICollection<SliderImage> SliderImage { get; set; }
    }
}
