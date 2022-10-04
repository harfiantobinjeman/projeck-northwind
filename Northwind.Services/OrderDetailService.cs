using AutoMapper;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(OrderDetailDto orderDetailDto)
        {
            //throw new NotImplementedException();
            var edit = _mapper.Map<OrderDetail>(orderDetailDto);
            _repositoryManager.OrderDetailRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<OrderDetailDto> GetOrderByIdService(int orderDetailId, bool trackChange)
        {
            //throw new NotImplementedException();
            var orderDetailModel = await _repositoryManager.OrderDetailRepository.GetOrderDetailByIdRepo(orderDetailId, trackChange);
            var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetailModel);
            return orderDetailDto;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrdersAllService(bool trackChange)
        {
            //throw new NotImplementedException();
            var orderDetailModel = await _repositoryManager.OrderDetailRepository.GetOrderDetailsAllRepo(trackChange);
            var orderModelDto = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetailModel);
            return orderModelDto;
        }

        public void Insert(OrderDetailDto orderDetailDto)
        {
            //throw new NotImplementedException();
            var insert = _mapper.Map<OrderDetail>(orderDetailDto);
            _repositoryManager.OrderDetailRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(OrderDetailDto orderDetailDto)
        {
            //throw new NotImplementedException();
            var remove = _mapper.Map<OrderDetail>(orderDetailDto);
            _repositoryManager.OrderDetailRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
