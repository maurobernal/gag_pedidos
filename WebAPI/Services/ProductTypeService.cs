using AutoMapper;
using WebAPI.DTOs;
using WebAPI.InfraStructure;
using WebAPI.Interface;
using WebAPI.Entities;

namespace WebAPI.Services;

public class ProductTypeService : IProductTypeService
{
    private readonly AppDBContext _conection;
    private readonly IMapper _mapper;
    public ProductTypeService(IMapper mapper)
    {
        _conection = new AppDBContext();
        _mapper = mapper;
    }

    public int AddProductType(ProductTypeDTO product_type)
    {
        var P = _mapper.Map<ProductType>(product_type);

        _conection.Add(P);
        _conection.SaveChanges();
        return product_type.id;
    }

    public bool UpdateProductType(ProductTypeDTO product_type)
    {

        var entity = _conection.ProductsTypes.Where(o => o.id == product_type.id).FirstOrDefault();
        if (entity == null) return false;

        entity = _mapper.Map<ProductType>(product_type);

        _conection.SaveChanges();

        return true;
    }

    public bool DeleteProductType(int ID)
    {
        var entity = _conection.ProductsTypes.Where(w => w.id == ID).FirstOrDefault();
        if (entity == null) return false;

        _conection.ProductsTypes.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public ProductTypeDTO SelectProductType(int ID) => _mapper.Map<ProductTypeDTO>(_conection.ProductsTypes.FirstOrDefault(o => o.id == ID && o.Active));


    public List<ProductTypeDTO> SelectListProductType() => _mapper.Map<List<ProductTypeDTO>>(_conection.ProductsTypes.Where(o => o.Active == true).ToList());

}
