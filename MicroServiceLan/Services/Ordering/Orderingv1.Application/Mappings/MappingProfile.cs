using AutoMapper;
using Orderingv1.Application.Features.Orders.Commands.CheckoutOrder;
using Orderingv1.Application.Features.Orders.Commands.UpdateOrder;
using Orderingv1.Application.ViewModel;
using Orderingv1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderingv1.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
