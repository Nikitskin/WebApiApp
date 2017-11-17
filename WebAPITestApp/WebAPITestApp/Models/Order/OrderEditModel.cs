using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPITestApp.Web.Models.Order
{
    public class OrderEditModel
    {

        [Required(ErrorMessage = "Request does not have ProductIds")]
        public ICollection<int> ProductIds { get; set; }

    }
}
