using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Mc2.CrudTest.Domain.Models;
using Mc2.CrudTest.Service.Core.Customer;
using Mc2.CrudTest.Testing.Models;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.Commands.Validation;
using Mc2CrudTest.Application.DTOs.Customer;
using Mc2CrudTest.Application.Handlers.Base;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Testing.Customer
{
    public class CreateCustomer
    {
        private Mock<ICustomerService> _service;
        private IMapper _mapper;
        public CreateCustomer()
        {
            _service = new Mock<ICustomerService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Mc2.CrudTest.Domain.Models.Customer, CreateCustomerRequest>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }

        [Theory]
        [ClassData(typeof(CreateCustomerRequestTest))]
        public async Task CreateCustomer_WithValidData_ShouldSucceed(CreateCustomerCommand request)
        {
            _service.Setup(x => x.AddAndSaveAsync(It.IsAny<Domain.Models.Customer>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Mc2CrudTest.Application.Handlers.Customer.CreateCustomerHandler(_service.Object, _mapper);
            var res = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(res);
            Assert.True(res.IsSucceed);
        }

        [Theory]
        [ClassData(typeof(CreateCustomerRequestInvalidNoTest))]
        public async Task CreateCustomer_WithInValidData_ShouldFail(CreateCustomerCommand request)
        {
            // Arrange
            var validators = new List<IValidator<CreateCustomerCommand>>();

            var validator = new CreateCustomerValidation();

            validators.Add(validator); 

            _service.Setup(x => x.AddAndSaveAsync(It.IsAny<Domain.Models.Customer>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Mc2CrudTest.Application.Handlers.Customer.CreateCustomerHandler(_service.Object, _mapper);

            var behavior = new ValidationBehaviour<CreateCustomerCommand, CreateCustomerResponse>(validators);


            Func<Task> act = async () => await behavior.Handle(request, () => handler.Handle(request, CancellationToken.None), CancellationToken.None);

            // Assert: Ensure that a ValidationException is thrown
            await Assert.ThrowsAsync<FluentValidation.ValidationException>(act);
        }

        private Mc2.CrudTest.Domain.Models.Customer GetSampleData()
        {
            return new Domain.Models.Customer
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890", // Valid mobile number
                BankAccountNumber = "12345678901234567890" // Valid bank account number
            };
        }
    }
}
