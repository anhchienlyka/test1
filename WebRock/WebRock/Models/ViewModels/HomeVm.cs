using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRock.Models.ViewModels
{
    public class HomeVm
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool ExistsInCart { get; set; }
    }
}
