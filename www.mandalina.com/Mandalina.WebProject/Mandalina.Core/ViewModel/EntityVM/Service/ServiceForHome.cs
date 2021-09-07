using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.Core.ViewModel.EntityVM.Service
{
    public class ServiceForHome
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public string ShortText { get; set; }
        public int CategoryId { get; set; }
    }
}
