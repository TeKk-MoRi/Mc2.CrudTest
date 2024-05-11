using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Service.Core.Customer;
using Mc2.CrudTest.Testing.Models;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.Commands.Validation;
using Mc2CrudTest.Application.DTOs.Customer;
using Mc2CrudTest.Application.Handlers.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Testing.Customer
{
    public class DeleteCustomer
    {
        private Mock<ICustomerService> _service;
        private IMapper _mapper;
        public DeleteCustomer()
        {
            _service = new Mock<ICustomerService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Mc2.CrudTest.Domain.Models.Customer, DeleteCustomerRequest>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }

        [Theory]
        [ClassData(typeof(DeleteCustomerRequestTest))]
        public async Task DeleteCustomer_WithValidData_ShouldSucceed(DeleteCustomerCommand request)
        {
            _service.Setup(x => x.DeleteAndSaveAsync(It.IsAny<Domain.Models.Customer>()));

            var handler = new Mc2CrudTest.Application.Handlers.Customer.DeleteCustomerHandler(_service.Object, _mapper);
            var res = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(res);
            Assert.True(res.IsSucceed);
        }

        [Theory]
        [ClassData(typeof(DeleteCustomerRequestInvalidNoTest))]
        public async Task DeleteCustomer_WithInValidData_ShouldFail(DeleteCustomerCommand request)
        {
            // Arrange
            var validators = new List<IValidator<DeleteCustomerCommand>>();

            var validator = new DeleteCustomerValidation();

            validators.Add(validator);

            _service.Setup(x => x.DeleteAndSaveAsync(It.IsAny<Domain.Models.Customer>()));

            var handler = new Mc2CrudTest.Application.Handlers.Customer.DeleteCustomerHandler(_service.Object, _mapper);

            var behavior = new ValidationBehaviour<DeleteCustomerCommand, DeleteCustomerResponse>(validators);


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
