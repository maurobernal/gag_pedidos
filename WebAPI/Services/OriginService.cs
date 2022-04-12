using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.InfraStructure;
using WebAPI.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services;

public class OriginService : IOriginService
{
    private readonly AppDBContext _conection;
    private readonly IMapper _mapper;

    public OriginService(IMapper mapper)
    {
        _conection = new AppDBContext();
        _mapper = mapper;
    }
    public OriginDTO AddOrigin(OriginDTO origin)
    {

        var O = _mapper.Map<Origin>(origin);

        _conection.Add(O);
        _conection.SaveChanges();

        return _mapper.Map<OriginDTO>(O);
    }

    public OriginDTO UpdateOrigin(OriginDTO origin)
    {

        var entity = _conection.Origins.Where(o => o.id == origin.id).AsNoTracking().FirstOrDefault();
        if (entity == null) throw new Exception();

        entity = _mapper.Map<Origin>(origin);
        _conection.Origins.Update(entity);
        _conection.SaveChanges();

        return _mapper.Map<OriginDTO>(entity);
    }

    public bool DeleteOrigin(int ID)
    {
        var entity = _conection.Origins.Where(o => o.id == ID).FirstOrDefault();
        if (entity == null) return false;

        _conection.Origins.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public OriginDTO SelectOrigin(int ID) => _mapper.Map<OriginDTO>(_conection.Origins.FirstOrDefault(o => o.id == ID && o.Active));

    public List<OriginDTO> SelectListOrigin(string option)
    {
        List<Origin> list = new List<Origin>();

        list = _conection.Origins
            .Where(w =>
                (option == "T") ||
                (option == "H" && w.Active == true) ||
                (option == "NH" && w.Active == false)
            )
            .ToList();
        return _mapper.Map<List<OriginDTO>>(list);


    }

}
