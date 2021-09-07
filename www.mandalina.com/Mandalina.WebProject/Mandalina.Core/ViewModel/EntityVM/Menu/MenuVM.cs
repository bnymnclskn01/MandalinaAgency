using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Menu
{
    public class MenuVM
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string UrlPath { get; set; }
        public int PropertyId { get; set; }
        public int LanguageId { get; set; }
        public int Id { get; set; }

    }
}
