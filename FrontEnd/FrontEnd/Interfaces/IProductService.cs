using FrontEnd.Models;

namespace FrontEnd.Interfaces;
public interface IProductService
{
    public Task<List<ProductModel>> GetAll();
    public Task<ProductModel> Get(int id);
    public Task<ProductModel> Update(ProductModel productModel);
    public Task<ProductModel> Add(ProductModel productModel);
    public Task Delete(int id);

}
