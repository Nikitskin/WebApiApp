using System.Collections.ObjectModel;

namespace WebAPITestApp.Models.ProductControllers
{
    public class ProductFullModel : ProductCoreModel
    {
        public int Id { get; set; }

        public Collection<int> OrderIds { get; set; }
    }
}
