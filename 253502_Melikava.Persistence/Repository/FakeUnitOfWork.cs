using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly IRepository<MenuPosition> _menuPositionRepository;
        private readonly IRepository<Order> _orderRepository;

        public FakeUnitOfWork()
        {
            _menuPositionRepository = new FakeMenuPositionRepository();
            _orderRepository = new FakeOrderRepository();
        }
        public IRepository<MenuPosition> MenuPositionRepository => _menuPositionRepository;
        public IRepository<Order> OrderRepository => _orderRepository;

        public Task CreateDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
