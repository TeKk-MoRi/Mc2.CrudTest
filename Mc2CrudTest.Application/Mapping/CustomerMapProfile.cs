using AutoMapper;
using Mc2CrudTest.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Mapping
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<Mc2.CrudTest.Domain.Models.Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Mc2.CrudTest.Domain.Models.Customer, UpdateCustomerRequest>().ReverseMap();
            CreateMap<Mc2.CrudTest.Domain.Models.Customer, CustomerDto>().ReverseMap();
        }
    }
}
