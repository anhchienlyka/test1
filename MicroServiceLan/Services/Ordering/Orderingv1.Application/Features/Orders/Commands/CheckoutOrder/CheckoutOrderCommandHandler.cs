﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Orderingv1.Application.Contracts.Infrastructure;
using Orderingv1.Application.Contracts.Persistence;
using Orderingv1.Application.Models;
using Orderingv1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Orderingv1.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {

            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            await SendMail(newOrder);
            return newOrder.Id;


        }
        private async Task SendMail(Order order)
        {
            var email = new Email() { To = "lan1796@gmail.com", Body = $"Order was created.", Subject = "Order was created"};
            try
            {
                await _emailService.SendEmail(email);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the email service: {ex.Message}");
            }
        }
    }
}