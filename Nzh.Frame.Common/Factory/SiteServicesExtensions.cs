using Microsoft.Extensions.DependencyInjection;
using Nzh.Frame.IRepository;
using Nzh.Frame.IService;
using Nzh.Frame.Repository;
using Nzh.Frame.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Common.Factory
{
    public static class SiteServicesExtensions
    {
        /// <summary>
        /// 注入服务、仓储类
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IDemoRepository, DemoRepository>();
            services.AddScoped<IDemoService, DemoService>();

            return services;

        }
    }
}
