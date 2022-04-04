using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    public interface IOrigenService
    {
        int AddOrigen(OrigenDTO origen);
        bool DeleteOrigen(int ID);
        List<Origen> SelectListOrigen();
        OrigenDTO SelectOrigen(int ID);
        bool UpdateOrigen(OrigenDTO origen);
    }
}