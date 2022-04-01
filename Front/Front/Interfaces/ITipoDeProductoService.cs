using Front.Models;

namespace Front.Interfaces;

public interface ITipoDeProductoService
{
    public Task<TipoDeProductoModels> Add(TipoDeProductoModels T);
    public Task<List<TipoDeProductoModels>> GetAll();

    public Task<TipoDeProductoModels> Get(int id);

    public Task<TipoDeProductoModels> Edit(TipoDeProductoModels T);

    public Task Delete(int id);

}
