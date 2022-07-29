using BikeShop.Core.Features.Customers;
using BikeShop.Core.UseCases.Customers;

namespace BikeShop.Core.Features.Customers
{
    public static partial class CustomerMapper
    {
        public static CustomerDto AdaptToDto(this Customer p1)
        {
            return p1 == null ? null : new CustomerDto()
            {
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Dob = p1.Dob,
                PreviousStatus = p1.PreviousStatus,
                Status = p1.Status,
                Id = new CustomerId(p1.Id.Value),
                CreatedDate = p1.CreatedDate
            };
        }
        public static CustomerDto AdaptTo(this Customer p2, CustomerDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CustomerDto result = p3 ?? new CustomerDto();
            
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Dob = p2.Dob;
            result.PreviousStatus = p2.PreviousStatus;
            result.Status = p2.Status;
            result.Id = new CustomerId(p2.Id.Value);
            result.CreatedDate = p2.CreatedDate;
            return result;
            
        }
    }
}