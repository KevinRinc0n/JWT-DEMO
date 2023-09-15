using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly JwtDemoContext _context;

    public ProductoRepository(JwtDemoContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Producto>> GetProductosMasCaros(int cantidad) =>
    await _context.Productos
    .OrderByDescending(p => p.Precio)
    .Take(cantidad)
    .ToListAsync();

    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
        .Include(p => p.Marca)
        .Include(p => p.Categoria)
        .FirstOrDefaultAsync(p => p.Id == id);  
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
        .Include(u => u.Marca)
        .Include(u => u.Categoria)
        .ToListAsync();
    }
}