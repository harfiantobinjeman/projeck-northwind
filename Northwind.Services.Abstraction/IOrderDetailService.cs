using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetOrdersAllService(bool trackChange);

        Task<OrderDetailDto> GetOrderByIdService(int orderDetailId, bool trackChange);

        void Insert(OrderDetailDto orderDetailDto);

        void Edit(OrderDetailDto orderDetailDto);

        void Remove(OrderDetailDto orderDetailDto);
    }
}
