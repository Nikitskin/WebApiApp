using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.Models.OrderControllers
{
    public class OrderCoreModel
    {
        [JsonProperty("ordered_date")]
        [JsonRequired, DisplayName("ordered_date")]
        public DateTime OrderedDate { get; set; }

        [JsonIgnore]
        public string UserName { get; set; }

        public ICollection<ProductFullModel> Products { get; set; }
    }
}
