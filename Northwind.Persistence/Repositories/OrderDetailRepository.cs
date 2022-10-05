using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(OrderDetail orderDetail)
        {
            //throw new NotImplementedException();
            Edit(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailByIdRepo(int orderDetaiId, bool trackchange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(p => p.OrderId.Equals(orderDetaiId), trackchange)
                .OrderBy(p => p.OrderId)
                .Include(o => o.ProductId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAllRepo(bool trackchange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackchange)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Order)
                .Include(d => d.Product)
                .ToListAsync();
        }

        public void Insert(OrderDetail orderDetail)
        {
            //throw new NotImplementedException();
            Create(orderDetail);
        }

        public void Remove(OrderDetail orderDetail)
        {
            //throw new NotImplementedException();
            Delete(orderDetail);
        }
    }
}
