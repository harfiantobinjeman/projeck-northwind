using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAllService(bool trackChange);

        Task<OrderDto> GetOrderByIdService(int orderId, bool trackChange);

        void Insert(OrderDto orderDto);

        void Edit(OrderDto orderDto);

        void Remove(OrderDto orderDto);
    }
}
