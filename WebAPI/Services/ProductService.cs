using WebAPI.Entities;
using WebAPI.InfraStructure;

namespace WebAPI.Services;

public class ProductService
{
    private readonly AppDBContext _conection;
    public ProductService()
    {
        _conection = new AppDBContext();
    }

    public int AddProduct(Product product)
    {
        _conection.Products.Add(product);
        _conection.SaveChanges();

        return product.id;
    }

    public bool UpdateProduct(Product product)
    {

        var entity = _conection.Products.Where(p => p.id == product.id).FirstOrDefault();
        if (entity == null) return false;

        entity.Description = product.Description;
        entity.Active = product.Active;

        _conection.SaveChanges();

        return true;
    }

    public bool DeleteProduct(int ID)
    {
        var entity = _conection.Products.Where(p => p.id == ID).FirstOrDefault();
        if (entity == null) return false;
        _conection.Products.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public Product SelectProduct(int ID) => _conection.Products.FirstOrDefault(p => p.id == ID && p.Active);


    public List<Product> SelectListProduct() => _conection.Products.Where(p => p.Active == true).ToList();

}
