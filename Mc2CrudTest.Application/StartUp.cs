using FluentValidation;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.Commands.Validation;
using Mc2CrudTest.Application.Handlers.Base;
using MediatR;
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


            services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerValidation>();
            services.AddTransient<IValidator<UpdateCustomerCommand>, UpdateCustomerValidation>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


        }
    }
}
