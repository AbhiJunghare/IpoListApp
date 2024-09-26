using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IpoList.Models
{
    public class IpoModel
    {

        public int Id { get; set; }
        [DisplayName("Stock Name")]
        [Required(ErrorMessage = "Stock Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Stock Name must contain only alphabetic characters and spaces.")]
        public string StockName { get; set; }

        [DisplayName("Listing Price")]
        [Required(ErrorMessage = "Listing Price is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid decimal value for Listing Price.")]
        public string ListingPrice { get; set; }

        [DisplayName("Listing Date")]
        [Required(ErrorMessage = "Listing Date is required.")]
        public DateTime ListingDate { get; set; }

    }
}
