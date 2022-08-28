using MediatR;
using Orderingv1.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderingv1.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetordersListQuery : IRequest<List<OrdersVm>>
    {
        public string UserName { get; set; }
        public GetordersListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
