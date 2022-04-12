using WebAPI.DTOs;

namespace WebAPI.Interface;
public interface IOriginService
{
    OriginDTO AddOrigin(OriginDTO origin);
    bool DeleteOrigin(int ID);
    List<OriginDTO> SelectListOrigin(string option);
    OriginDTO SelectOrigin(int ID);
    OriginDTO UpdateOrigin(OriginDTO origin);
}
