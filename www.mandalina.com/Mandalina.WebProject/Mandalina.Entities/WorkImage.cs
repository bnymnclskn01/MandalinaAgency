using Mandalina.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Entities
{
    public class WorkImage : BaseEntity3
    {
        public string ImageUrl { get; set; }
        public int WorkID { get; set; }
        public Work Work { get; set; }
    }
}
