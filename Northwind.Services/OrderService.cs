using AutoMapper;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Base;
using Northwind.Domain.Entities;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(OrderDto orderDto)
        {
            //throw new NotImplementedException();
            var edit = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrdersRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<OrderDto> GetOrderByIdService(int orderId, bool trackChange)
        {
            //throw new NotImplementedException();
            var orderModel = await _repositoryManager.OrdersRepository.GetOrderByIdRepo(orderId, trackChange);
            var ordertDto = _mapper.Map<OrderDto>(orderModel);
            return ordertDto;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAllService(bool trackChange)
        {
            //throw new NotImplementedException();
            var orderModel = await _repositoryManager.OrdersRepository.GetOrdersAllRepo(trackChange);
            var orderDto = _mapper.Map<IEnumerable<OrderDto>>(orderModel);
            return orderDto;
        }

        public void Insert(OrderDto orderDto)
        {
            //throw new NotImplementedException();
            var insert = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrdersRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(OrderDto orderDto)
        {
            //throw new NotImplementedException();
            var remove = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrdersRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
