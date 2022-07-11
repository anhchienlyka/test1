using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRock.Models.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            Product = new Product();
        }
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<SelectListItem> TypeSelectList { get; set; }
        public bool ExistsInCart { get; set; }
    }
}
