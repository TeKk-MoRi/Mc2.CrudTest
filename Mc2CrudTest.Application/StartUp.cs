using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application
{
    public static class StartUp
    {
        public static void Start(IServiceCollection services)
        {
            Mc2.CrudTest.Service.StartUp.Start(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
