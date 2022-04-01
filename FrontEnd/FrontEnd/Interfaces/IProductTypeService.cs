using FrontEnd.Models;

namespace FrontEnd.Interfaces;
public interface IProductTypeService
{
    public Task<List<ProductTypeModel>> GetAll();
    public Task<ProductTypeModel> Get(int id);
    public Task<ProductTypeModel> Update(ProductTypeModel productTypeModel);
    public Task Delete(int id);
    public Task<ProductModel> Add(ProductTypeModel productTypeModel);


}
