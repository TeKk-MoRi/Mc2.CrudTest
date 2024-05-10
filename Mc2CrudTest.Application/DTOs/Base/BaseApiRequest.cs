using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.DTOs.Base
{
    public abstract class BaseApiRequest
    {
    }

    public abstract class BaseApiRequest<T> : BaseApiRequest
    {
        public T ViewModel { get; set; }
    }

}
