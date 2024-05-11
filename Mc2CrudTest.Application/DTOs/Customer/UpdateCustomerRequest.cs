using Mc2CrudTest.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.DTOs.Customer
{
    public class UpdateCustomerRequest : BaseApiRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
