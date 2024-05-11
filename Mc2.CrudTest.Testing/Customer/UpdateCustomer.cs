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
    public class UpdateCustomer
    {
        private Mock<ICustomerService> _service;
        private IMapper _mapper;
        public UpdateCustomer()
        {
            _service = new Mock<ICustomerService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Mc2.CrudTest.Domain.Models.Customer, UpdateCustomerRequest>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }

        [Theory]
        [ClassData(typeof(UpdateCustomerRequestTest))]
        public async Task CreateCustomer_WithValidData_ShouldSucceed(UpdateCustomerCommand request)
        {
            _service.Setup(x => x.UpdateAndSaveAsync(It.IsAny<Domain.Models.Customer>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Mc2CrudTest.Application.Handlers.Customer.UpdateCustomerHandler(_service.Object, _mapper);
            var res = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(res);
            Assert.True(res.IsSucceed);
        }

        [Theory]
        [ClassData(typeof(UpdateCustomerRequestInvalidNoTest))]
        public async Task CreateCustomer_WithInValidData_ShouldFail(UpdateCustomerCommand request)
        {
            // Arrange
            var validators = new List<IValidator<UpdateCustomerCommand>>();

            var validator = new UpdateCustomerValidation();

            validators.Add(validator);

            _service.Setup(x => x.UpdateAndSaveAsync(It.IsAny<Domain.Models.Customer>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Mc2CrudTest.Application.Handlers.Customer.UpdateCustomerHandler(_service.Object, _mapper);

            var behavior = new ValidationBehaviour<UpdateCustomerCommand, UpdateCustomerResponse>(validators);


            Func<Task> act = async () => await behavior.Handle(request, () => handler.Handle(request, CancellationToken.None), CancellationToken.None);

            // Assert: Ensure that a ValidationException is thrown
            await Assert.ThrowsAsync<FluentValidation.ValidationException>(act);
        }

        private int GetSampleData()
        {
            return 3;
        }
    }
}
