using WebAPI.DTOs;

namespace WebAPI.Interface;
public interface IProductService
{
    ProductDTO AddProduct(ProductDTO product);
    bool DeleteProduct(int ID);
    List<ProductDTO> SelectListProduct();
    ProductDTO SelectProduct(int ID);
    ProductDTO UpdateProduct(ProductDTO product);
}
