using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace WebAPITestApp.Models
{
    public class OrderModel
    {
        [JsonProperty("ordered_date")]
        [JsonRequired, DisplayName("ordered_date")]
        public DateTime OrderedDate { get; set; }
        //todo shall i create a buffer class ProducetOrder that will not contain link to itself?
        public ICollection<ProductModel> Products { get; set; }
    }
}
