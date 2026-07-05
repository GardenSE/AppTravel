using System;
using System.Collections.Generic;
using System.Text;
using AppTravel.Features.M_Customer;
using AppTravel.Features.M_Customer.Services;

namespace AppTravel.Infrastructure.DI
{
    public static partial class FeatureRegistrationExtensions
    {
        /// <summary>
        /// 全FeatureのDIを登録する
        /// </summary>
        public static IServiceCollection AddFeatures(this IServiceCollection services)
        {
            services.AddM_CustomerFeature();

            // 将来増えたらここへ追加
            // .AddM_ProductFeature()
            // .AddM_SupplierFeature();

            return services;
        }
    }
}
