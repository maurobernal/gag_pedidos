using FrontEnd.Models;

namespace FrontEnd.Interfaces;

public interface IOriginService
{
    public Task<List<OriginModel>> GetAll();

    public Task<OriginModel> Get(int id);

    public Task<OriginModel> Update(OriginModel originModel);

    public Task Delete(int id);

    public Task<OriginModel> Add(OriginModel originModel);

}
