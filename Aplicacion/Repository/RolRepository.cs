using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly JwtDemoContext _context;

    public RolRepository(JwtDemoContext context) : base(context)
    {
       _context = context;
    }
}