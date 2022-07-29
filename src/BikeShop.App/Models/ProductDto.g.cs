using System;
using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;
using BikeShop.Core.UseCases.Products;

namespace BikeShop.Core.Features.Products
{
    public partial class ProductDto
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public ProductId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}