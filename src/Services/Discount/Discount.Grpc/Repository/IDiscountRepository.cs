using Discountv1.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discountv1.Grpc.Repository
{
    public interface IDiscountRepository
    {
        Task<Couponcs> GetDiscount(string productName);

        Task<bool> CreateDiscount(Couponcs coupon);
        Task<bool> UpdateDiscount(Couponcs coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
