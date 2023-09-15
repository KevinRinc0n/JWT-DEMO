using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class MarcaReository : GenericRepository<Marca>, IMarca
{
    private readonly JwtDemoContext _context;

    public MarcaReository(JwtDemoContext context) : base(context)
    {
       _context = context;
    }
}