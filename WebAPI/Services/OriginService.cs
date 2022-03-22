using WebAPI.Entities;

namespace WebAPI.Services;

public class OriginService
{
    public OriginService()
    {
        entities = new();
    }

    public List<Origin> entities { get; set; }
    public int AddOrigin(Origin origin)
    {
        origin.id = new Random().Next(100000);
        entities.Add(origin);
        return origin.id;
    }

    public bool UpdateOrigin(Origin origin)
    {

        var entity = entities.Where(o => o.id == origin.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = origin.Description;
        entity.Active = origin.Active;

        entities.Add(origin);
        return true;
    }

    public bool DeleteOrigin(int ID)
    {
        var entity = entities.Where(o => o.id == ID).FirstOrDefault();
        if (entity == null) return false;
        entities.Remove(entity);
        return true;

    }

    public Origin SelectOrigin(int ID) => entities.FirstOrDefault(o => o.id == ID && o.Active);


    public List<Origin> SelectListOrigin() => entities.Where(o => o.Active == true).ToList();

}
