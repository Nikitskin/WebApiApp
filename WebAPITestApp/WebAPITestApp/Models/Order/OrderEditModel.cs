using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPITestApp.Models.Order
{
    public class OrderEditModel
    {

        [Required(ErrorMessage = "Request does not have ProductIds")]
        public ICollection<int> ProductIds { get; set; }

    }
}
