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
    public class SliderImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Slider")]
        public int SliderId { get; set; }

        [StringLength(110)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Alt { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }

        public int Rank { get; set; }

        public DateTime LastDateTime { get; set; }

        public bool IsActivited { get; set; }

        public virtual Sliders Slider { get; set; }
    }
}
