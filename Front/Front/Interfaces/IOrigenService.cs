using Front.Models;

namespace Front.Interfaces;

public interface IOrigenService
{
    public Task<OrigenModels> Add(OrigenModels O);
    public Task<List<OrigenModels>> GetAll();

    public Task<OrigenModels> Get(int id);

    public Task<OrigenModels> Edit(OrigenModels O);

    public Task Delete(int id);

}
