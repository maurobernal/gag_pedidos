using WebAPI.DTOs;

namespace WebAPI.Interface;
public interface IProductService
{
    ProductDTO AddProduct(ProductDTO product);
    bool DeleteProduct(int ID);
    List<ProductDTO> SelectListProduct();
    List<ProductDTO> SelectListProduct(string option);
    ProductDTO SelectProduct(int ID);
    ProductDTO UpdateProduct(ProductDTO product);
}
