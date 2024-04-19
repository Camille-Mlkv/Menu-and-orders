using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.Persistence.Repository
{
    public class FakeMenuPositionRepository : IRepository<MenuPosition>
    {
        List<MenuPosition> _menuPositions;

        public FakeMenuPositionRepository()
        {
            _menuPositions = new List<MenuPosition>();
            var menuPosition = new MenuPosition("Pizza", "Margarita", 10.5);
            menuPosition.Id = 1;
            _menuPositions.Add(menuPosition);

            menuPosition = new MenuPosition("Cocktail", "Summer", 3.5);
            menuPosition.Id = 2;
            _menuPositions.Add(menuPosition);
        }
        public Task AddAsync(MenuPosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MenuPosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MenuPosition> FirstOrDefaultAsync(Expression<Func<MenuPosition, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MenuPosition> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<MenuPosition, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MenuPosition>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _menuPositions);
        }

        public Task<IReadOnlyList<MenuPosition>> ListAsync(Expression<Func<MenuPosition, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<MenuPosition, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MenuPosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeOrderRepository : IRepository<Order>
    {
        List<Order> _orders=new List<Order>();
        public FakeOrderRepository() 
        {
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                {
                    var order = new Order($"Client {k++}", Random.Shared.NextDouble(), Random.Shared.NextDouble() > 0.5, $"Sauce {k++}");
                    order.AddToMenuPosition(i);
                    _orders.Add(order);
                }
        }
        public Task AddAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Order, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> ListAsync(Expression<Func<Order, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Order, object>>[] includesProperties)
        {
            var query = _orders.AsQueryable();
            if (includesProperties != null)
            {
                foreach (var includeProperty in includesProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if(filter!= null)
            {
                query = query.Where(filter);
            }
            return Task.FromResult<IReadOnlyList<Order>>(query.ToList());
        }

        public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
