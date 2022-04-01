using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.InfraStructure;
using WebAPI.Interface;

namespace WebAPI.Services;

public class ProductService : IProductService
{
    private readonly AppDBContext _conection;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper)
    {
        _conection = new AppDBContext();
        _mapper = mapper;
    }

    public ProductDTO AddProduct(ProductDTO product)
    {   
        var P = _mapper.Map<Product>(product);

        _conection.Add(P);
        _conection.SaveChanges();

        return _mapper.Map<ProductDTO>(P);
    }

    public ProductDTO UpdateProduct(ProductDTO product)
    {

        var entity = _conection.Products.Where(p => p.id == product.id).AsNoTracking().FirstOrDefault();
        if (entity == null) throw new Exception();

        entity = _mapper.Map<Product>(product);
        _conection.Products.Update(entity);
        _conection.SaveChanges();

        return _mapper.Map<ProductDTO>(entity);
    }

    public bool DeleteProduct(int ID)
    {
        var entity = _conection.Products.Where(p => p.id == ID).FirstOrDefault();
        if (entity == null) return false;

        _conection.Products.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public ProductDTO SelectProduct(int ID) => _mapper.Map<ProductDTO>(_conection.Products.FirstOrDefault(p => p.id == ID && p.Active));


    public List<ProductDTO> SelectListProduct() => _mapper.Map<List<ProductDTO>>(_conection.Products.Where(p => p.Active == true).ToList());

}

