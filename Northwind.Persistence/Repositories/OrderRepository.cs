using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Order order)
        {
            //throw new NotImplementedException();
            Edit(order);
        }

        public async Task<Order> GetOrderByIdRepo(int orderId, bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(p => p.OrderId.Equals(orderId), trackChange)
                .OrderBy(p => p.OrderId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAllRepo(bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackChange)
                .Include(c =>c.Customer)
                .Include(d => d.Employee)
                .ToListAsync();
        }

        public void Insert(Order order)
        {
            //throw new NotImplementedException();
            Create(order);
        }

        public void Remove(Order order)
        {
            //throw new NotImplementedException();
            Delete(order);
        }
    }
}
