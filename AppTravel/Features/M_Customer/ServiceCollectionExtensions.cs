using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer.Views;
using AppTravel.Features.M_Customer.Services;
using AppTravel.Features.M_Customer.ViewModels;

namespace AppTravel.Features.M_Customer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddM_CustomerFeature(this IServiceCollection services) 
        {
            services.AddTransient<M_CustomerPage>();

            services.AddTransient<M_CustomerViewModel>();

            services.AddTransient<IM_CustomerService, M_CustomerService>();

            // 将来Repositoryを追加したらここ
            // services.AddTransient<IM_CustomerRepository, M_CustomerRepository>();

            return services;
        }
    }
}
