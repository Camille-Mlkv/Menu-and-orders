using _253502_Melikava.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            var menuPositions = new List<MenuPosition>();

            var menuPosition = new MenuPosition("Pizza", "Diablo", 10.5);
            menuPosition.Id = 1;
            menuPositions.Add(menuPosition);

            menuPosition = new MenuPosition("Cocktail", "Fresh", 3.5);
            menuPosition.Id = 2;
            menuPositions.Add(menuPosition);

            menuPosition = new MenuPosition("Dessert", "Ice", 2.5);
            menuPosition.Id = 3;
            menuPositions.Add(menuPosition);

            foreach (var item in menuPositions)
            {
                await unitOfWork.MenuPositionRepository.AddAsync(item);
            }
            await unitOfWork.SaveAllAsync();

            var orders=new List<Order>();
            int k = 0;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    k++;
                    var order = new Order($"Client {k}", Random.Shared.Next(10, 21), Random.Shared.NextDouble() > 1, $"Sauce {k}");
                    order.AddToMenuPosition(i);
                    orders.Add(order);
                }
            }
            foreach (var order in orders)
            {
                await unitOfWork.OrderRepository.AddAsync(order);
            }
            await unitOfWork.SaveAllAsync();

        }
    }
}
