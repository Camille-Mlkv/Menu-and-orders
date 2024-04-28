using _253502_Melikava.UI.Pages;
using _253502_Melikava.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<MenuPositionsPage>()
                    .AddTransient<OrderDetails>()
                    .AddTransient<AddNewOrderPage>()
                    .AddTransient<AddNewMenuPositionPage>()
                    .AddTransient<EditMenuPositionPage>()
                    .AddTransient<EditOrderPage>();
                    
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<MenuPositionsPageViewModel>()
                    .AddTransient<OrderDetailsViewModel>()
                    .AddTransient<AddNewOrderPageViewModel>()
                    .AddTransient<AddNewMenuPositionPageViewModel>()
                    .AddTransient<EditMenuPositionPageViewModel>()
                    .AddTransient<EditOrderPageViewModel>();
            return services;
        }


    }
}
