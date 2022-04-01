using Front.Models;

namespace Front.Interfaces;

public interface IProductoService
{
    public Task<ProductoModels> Add(ProductoModels O);

    public Task<List<ProductoModels>> GetAll();

    public Task<ProductoModels> Get(int id);

    public Task<ProductoModels> Edit(ProductoModels O);

    public Task Delete(int id);

}
