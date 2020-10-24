using Core.Entities;

namespace Core.Specifications {
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpec() {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}