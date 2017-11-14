
using System.ComponentModel.DataAnnotations;

namespace WebAPITestApp.Models.Product
{
    public class ProductCoreModel
    {
        [Required(ErrorMessage = "There is no ProductName in request")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "There is no Description in request")]
        public string Description { get; set; }

        [Required(ErrorMessage = "There is no Costs in request")]
        public double Costs { get; set; }
    }
}
