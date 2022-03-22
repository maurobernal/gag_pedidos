using WebAPI.Entities;
namespace WebAPI.Services;

public class Service
{
    public Service()
    {
        entidades = new();
    }
    public List<Origen> entidades { get; set; }
    public int AddOrigen(Origen origen)
    {
        origen.Id = new Random().Next(100000);
        entidades.Add(origen);
        return origen.Id;
    }

    public bool UpdateOrigen(Origen origen) {

        var entidad = entidades.Where(o => o.Id == origen.Id ).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = origen.Descripcion;
        entidad.Habilitado = origen.Habilitado;

        entidades.Add(origen);
        return true;
    }

    public bool DeleteOrigen(int ID)
    {
        var entidad = entidades.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        entidades.Remove(entidad);
        return true;

    }

    public Origen SelectOrigen(int ID) 
  => entidades.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<Origen> SelectListOrigen() =>
        entidades.Where(o => o.Habilitado == true).ToList();



}
