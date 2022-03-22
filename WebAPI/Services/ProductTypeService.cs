using WebAPI.Entities;
namespace WebAPI.Services;

public class ProductTypeService
{
    public ProductTypeService()
    {
        entities = new();
    }

    public List<ProductType> entities { get; set; }
    public int AddProductType(ProductType product_type)
    {
        product_type.id = new Random().Next(100000);
        entities.Add(product_type);
        return product_type.id;
    }

    public bool UpdateProductType(ProductType product_type)
    {

        var entity = entities.Where(o => o.id == product_type.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = product_type.Description;
        entity.Active = product_type.Active;

        entities.Add(product_type);
        return true;
    }

    public bool DeleteProductType(int ID)
    {
        var entity = entities.Where(w => w.id == ID).FirstOrDefault();
        if (entity == null) return false;
        entities.Remove(entity);
        return true;

    }

    public ProductType SelectProductType(int ID) => entities.FirstOrDefault(o => o.id == ID && o.Active);


    public List<ProductType> SelectListProductType() => entities.Where(o => o.Active == true).ToList();

}
