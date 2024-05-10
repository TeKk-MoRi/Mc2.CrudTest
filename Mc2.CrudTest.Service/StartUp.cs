using Mc2.CrudTest.Service.Base;
using Mc2.CrudTest.Service.Core.Customer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Service
{
    public static class StartUp
    {
        public static void Start(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
