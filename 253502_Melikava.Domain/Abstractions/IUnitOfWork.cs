using _253502_Melikava.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<MenuPosition> MenuPositionRepository { get; }
        IRepository<Order> OrderRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();

    }
}
