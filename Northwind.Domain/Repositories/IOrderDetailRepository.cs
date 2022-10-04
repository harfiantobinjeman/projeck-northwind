using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsAllRepo(bool trackchange);

        Task<OrderDetail>GetOrderDetailByIdRepo(int orderDetaiId, bool trackchange);

        void Insert(OrderDetail orderDetail);

        void Edit(OrderDetail orderDetail);

        void Remove(OrderDetail orderDetail);
    }
}
