using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //IoC injectionları kontrol ettiğimiz yer
    public static class ServiceTool
    {
        //Burası mesela autofac'te verdiğimiz injectionları oluşturabilmemize yarar.
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
