using Mc2.CrudTest.Presentation.API.Base;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.Queries.Customer;
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCustomerCommand model)
        {
            var res = await _mediator.Send(model);
            return Response(res);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var res = await _mediator.Send(new GetCustomerByIdQuery(new Mc2CrudTest.Application.DTOs.Customer.GetCustomerByIdRequest { Id = id}));
            return Response(res);
        }
    }
}
