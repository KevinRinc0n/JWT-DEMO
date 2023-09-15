using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private readonly JwtDemoContext _context;

    public CategoriaRepository(JwtDemoContext context) : base(context)
    {
       _context = context;
    }
}