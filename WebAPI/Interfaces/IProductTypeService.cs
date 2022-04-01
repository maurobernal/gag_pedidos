using WebAPI.DTOs;

namespace WebAPI.Interface;

public interface IProductTypeService
{
    int AddProductType(ProductTypeDTO product_type);
    bool DeleteProductType(int ID);
    List<ProductTypeDTO> SelectListProductType();
    ProductTypeDTO SelectProductType(int ID);
    bool UpdateProductType(ProductTypeDTO product_type);
}
