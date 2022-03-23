using WebAPI.Entities;
using WebAPI.Infrastructure;
namespace WebAPI.Services;

public class OrigenService
{
    private readonly AppDBContext _conexion;
    public OrigenService()
    {
        _conexion = new AppDBContext();
    }
    public int AddOrigen(Origen origen)
    {
        _conexion.Add(origen);
        _conexion.SaveChanges();
        return origen.Id;
    }

    public bool UpdateOrigen(Origen origen) {

        var entidad = _conexion.Origenes.Where(o => o.Id == origen.Id ).FirstOrDefault();
        if (entidad == null) return false;

        entidad.Descripcion = origen.Descripcion;
        entidad.Habilitado = origen.Habilitado;

        _conexion.SaveChanges();
        return true;
    }

    public bool DeleteOrigen(int ID)
    {
        var entidad = _conexion.Origenes.Where(o => o.Id == ID).FirstOrDefault();
        if (entidad == null) return false;
        _conexion.Remove(entidad);
        _conexion.SaveChanges();
        return true;

    }

    public Origen SelectOrigen(int ID) 
  => _conexion.Origenes.Where(o => o.Id == ID && o.Habilitado == true).FirstOrDefault();


    public List<Origen> SelectListOrigen() =>
        _conexion.Origenes.Where(o => o.Habilitado == true).ToList();



}
