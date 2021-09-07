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
    public class Work : BaseEntity3
    {
        public Work()
        {
            this.WorkImages = new HashSet<WorkImage>();
        }
        public string Name { get; set; }

        public string Content { get; set; }

        public string Content2 { get; set; }

        public string Content3 { get; set; }

        public int  Rank { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        #region Checkbox
        public bool OneImage { get; set; }
        public bool TwoImage { get; set; }
        public bool ThreeImage { get; set; }
        public bool TextIsActive { get; set; }
        #endregion

        public ICollection<WorkImage> WorkImages { get; set; }
    }
}
