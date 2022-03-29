using WebAPI.DTOs;


namespace WebAPI.Interfaces;

public interface IOrigenService
{
    int AddOrigen(OrigenDTO origen);
    bool DeleteOrigen(int ID);
    List<OrigenDTO> SelectListOrigen();
    OrigenDTO SelectOrigen(int ID);
    bool UpdateOrigen(OrigenDTO origen);
}
