using AutoMapper;
using Mc2.CrudTest.Service.Core.Customer;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.DTOs.Customer;
using Mc2CrudTest.Application.Queries.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Mc2.CrudTest.Domain.Models;

namespace Mc2CrudTest.Application.Handlers.Customer
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public GetCustomerByIdHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            GetCustomerByIdResponse response = new();
             var res = await _customerService.GetByIdAsync(request.Request.Id);
            if (res is null)
            {
                response.Result = null;
                response.IsSucceed = false;
                response.Failed();
                response.FailedMessage("Customer not found");
                return response;
            }

            CustomerDto dto = _mapper.Map<CustomerDto>(res);

            response.Result = dto;
            response.IsSucceed = true;
            response.Succeed();
            return response;
        }
    }
}
