using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)] // Assuming a 20-digit bank account number
        public string BankAccountNumber { get; set; }
    }
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Set up uniqueness constraints
            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();

            // Store phone number as string to minimize space
            builder.Property(c => c.PhoneNumber).HasMaxLength(15);
        }
    }
}
