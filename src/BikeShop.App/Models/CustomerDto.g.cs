using System;
using BikeShop.Core.Features.Customers;

namespace BikeShop.Core.Features.Customers
{
    public partial class CustomerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Dob { get; set; }
        public Customer.CustomerStatus? PreviousStatus { get; set; }
        public Customer.CustomerStatus Status { get; set; }
        public CustomerId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}