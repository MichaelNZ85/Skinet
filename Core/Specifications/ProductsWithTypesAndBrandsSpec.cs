using Core.Entities;

namespace Core.Specifications {
  public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product> {
    public ProductsWithTypesAndBrandsSpec () {
      AddInclude (x => x.ProductType);
      AddInclude (x => x.ProductBrand);
    }

    public ProductsWithTypesAndBrandsSpec (int id) : base (x => x.Id == id) {
      AddInclude (x => x.ProductType);
      AddInclude (x => x.ProductBrand);
    }
  }
}