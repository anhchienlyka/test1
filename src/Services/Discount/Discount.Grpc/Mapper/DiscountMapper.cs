using AutoMapper;
using Discount.Grpc.Protos;
using Discountv1.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Mapper
{
    public class DiscountMapper : Profile
    {
        public DiscountMapper()
        {
            CreateMap<Couponcs, CouponModel>().ReverseMap();
        }
    }
}
