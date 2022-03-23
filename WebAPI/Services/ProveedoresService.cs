using AppDbContext;
using WebAPI.Models;
namespace WebAPI.Services
{
    public class ProveedoresService
    {
        private readonly MyA2Context  _context ;


        public ProveedoresService()
        {
            _context = new MyA2Context();
        }

        public List<Proveedore> GetProveedores()
        {
           return _context.Proveedores
                .Where(w=>w.Habilitado==true)
                .OrderBy(o=>o.Modificado)
                .ToList();
        }
    }
}
