using System.ComponentModel.DataAnnotations;

namespace BikeShop.UI.Pages.Products.Review
{
    public class Review
    {
        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int Rating { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Email { get; set; }

    }
}
