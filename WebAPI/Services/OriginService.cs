using WebAPI.DTOs;
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
    public int AddOrigin(OriginDTO origin)
    {
        Origin O = new Origin();   
        O.Description = origin.Description;
        O.Active = true;

        _conection.Origins.Add(O);
        _conection.SaveChanges();

        return O.id;
    }

    public bool UpdateOrigin(OriginDTO origin)
    {   
  
        var entity = _conection.Origins.Where(o => o.id == origin.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = origin.Description;

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
