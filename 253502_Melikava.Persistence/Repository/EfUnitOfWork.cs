using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253502_Melikava.Persistence.Data;

namespace _253502_Melikava.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<MenuPosition>> _menuPositionRepository;
        private readonly Lazy<IRepository<Order>> _orderRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _menuPositionRepository = new Lazy<IRepository<MenuPosition>>(() =>
            new EfRepository<MenuPosition>(context));
            _orderRepository = new Lazy<IRepository<Order>>(() =>
            new EfRepository<Order>(context));
        }
        public IRepository<MenuPosition> MenuPositionRepository => _menuPositionRepository.Value;
        public IRepository<Order> OrderRepository => _orderRepository.Value;

        public async Task CreateDataBaseAsync()=> await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync()=> await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync()=> await _context.SaveChangesAsync();
    }
}
