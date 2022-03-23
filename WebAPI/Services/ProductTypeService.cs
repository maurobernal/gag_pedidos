using WebAPI.Entities;
using WebAPI.InfraStructure;

namespace WebAPI.Services;

public class ProductTypeService
{
    private readonly AppDBContext _conection;

    public ProductTypeService()
    {
        _conection = new AppDBContext();
    }

    public int AddProductType(ProductType product_type)
    {
        _conection.ProductsTypes.Add(product_type);
        _conection.SaveChanges();
        return product_type.id;
    }

    public bool UpdateProductType(ProductType product_type)
    {

        var entity = _conection.ProductsTypes.Where(o => o.id == product_type.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = product_type.Description;
        entity.Active = product_type.Active;

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

    public ProductType SelectProductType(int ID) => _conection.ProductsTypes.FirstOrDefault(o => o.id == ID && o.Active);


    public List<ProductType> SelectListProductType() => _conection.ProductsTypes.Where(o => o.Active == true).ToList();

}
