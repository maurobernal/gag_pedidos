using WebAPI.Entities;
using WebAPI.InfraStructure;

namespace WebAPI.Services;

public class OriginService
{
    private readonly AppDBContext _conection;

    public OriginService()
    {
        _conection = new AppDBContext();
    }
    public int AddOrigin(Origin origin)
    {
        _conection.Origins.Add(origin);
        _conection.SaveChanges();

        return origin.id;
    }

    public bool UpdateOrigin(Origin origin)
    {

        var entity = _conection.Origins.Where(o => o.id == origin.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = origin.Description;
        entity.Active = origin.Active;

        _conection.SaveChanges();

        return true;
    }

    public bool DeleteOrigin(int ID)
    {
        var entity = _conection.Origins.Where(o => o.id == ID).FirstOrDefault();
        if (entity == null) return false;
        _conection.Origins.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public Origin SelectOrigin(int ID) => _conection.Origins.FirstOrDefault(o => o.id == ID && o.Active);


    public List<Origin> SelectListOrigin() => _conection.Origins.Where(o => o.Active == true).ToList();

}
