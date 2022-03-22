using WebAPI.Entities;

namespace WebAPI.Services;

public class ProductService
{
    public ProductService()
    {
        entities = new();
    }

    public List<Product> entities { get; set; }
    public int AddProduct(Product product)
    {
        product.id = new Random().Next(100000);
        entities.Add(product);
        return product.id;
    }

    public bool UpdateProduct(Product product)
    {

        var entity = entities.Where(p => p.id == product.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = product.Description;
        entity.Active = product.Active;

        entities.Add(product);
        return true;
    }

    public bool DeleteProduct(int ID)
    {
        var entity = entities.Where(p => p.id == ID).FirstOrDefault();
        if (entity == null) return false;
        entities.Remove(entity);
        return true;

    }

    public Product SelectProduct(int ID) => entities.FirstOrDefault(p => p.id == ID && p.Active);


    public List<Product> SelectListProduct() => entities.Where(p => p.Active == true).ToList();

}
