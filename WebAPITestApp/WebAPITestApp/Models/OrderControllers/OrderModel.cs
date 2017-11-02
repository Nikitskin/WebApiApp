using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using WebAPITestApp.Models.ProductControllers;

namespace WebAPITestApp.Models.OrderControllers
{
    public class OrderModel
    {
        public int Id { get; set; }

        [JsonProperty("ordered_date")]
        [JsonRequired, DisplayName("ordered_date")]
        public DateTime OrderedDate { get; set; }

        [JsonIgnore]
        public string UserName { get; set; }

        //todo shall i create a buffer class ProducetOrder that will not contain link to itself?
        public ICollection<ProductModel> Products { get; set; }
    }
}
