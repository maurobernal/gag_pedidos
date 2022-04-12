using FrontEnd.Models;

namespace FrontEnd.Interfaces;
public interface IProductService
{
    public Task<List<ProductModel>> GetProductsAsync();
    public Task<List<ProductModel>> GetAll(string option);
    public Task<ProductModel> Get(int id);
    public Task<ProductModel> Update(ProductModel productModel);
    public Task Delete(int id);
    public Task<ProductModel> Add(ProductModel productModel);

}
