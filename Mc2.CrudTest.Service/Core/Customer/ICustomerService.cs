using Mc2.CrudTest.Domain.Models;
using Mc2.CrudTest.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Service.Core.Customer
{
    public interface ICustomerService : IBaseService<Mc2.CrudTest.Domain.Models.Customer, long>
    {
    }
}
