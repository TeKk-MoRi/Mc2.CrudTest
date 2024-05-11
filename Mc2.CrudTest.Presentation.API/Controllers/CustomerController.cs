using Mc2.CrudTest.Presentation.API.Base;
using Mc2CrudTest.Application.Commands.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand model)
        {
            var res = await _mediator.Send(model);
            return Response(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand model)
        {
            var res = await _mediator.Send(model);
            return Response(res);
        }
    }
}
