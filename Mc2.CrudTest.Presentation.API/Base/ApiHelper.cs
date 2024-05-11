using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics.Contracts;
using System.Runtime;
using System;

namespace Mc2.CrudTest.Presentation.API.Base
{
    public class ApiHelper
    {
        private HttpContext _context;
        private readonly IMediator _mediator;

        public ApiHelper(HttpContext context, IMediator mediator)
        {
            this._context = context;
            this._mediator = mediator;
        }   
    }
}
