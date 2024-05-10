using Mc2.CrudTest.Datalayer.Context;
using Mc2.CrudTest.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Service.Core.Customer
{
    public class CustomerService : BaseService<Mc2.CrudTest.Domain.Models.Customer, long>, ICustomerService
    {
        public CustomerService(CrudTestContext context) : base(context)
        {
        }
    }
}
