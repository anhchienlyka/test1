using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discountv1.Grpc.Entities
{
    public class Couponcs
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
