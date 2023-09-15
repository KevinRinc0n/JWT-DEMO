using System.Globalization;
using System.Reflection;
using CsvHelper;
using Dominio.Entities;
using Microsoft.Extensions.Logging;

namespace Persistencia;

public class JwtDemoContextSeed
{
public static async Task SeedAsync(JwtDemoContext context, ILoggerFactory loggerFactory)
{
    try
    {
        var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.Marcas.Any())
        {
            using (var readerMarcas = new StreamReader(ruta + @"/Data/Csvs/marcas.csv"))
            {
                using (var csvMarcas = new CsvReader(readerMarcas, CultureInfo.InvariantCulture))
                {
                    var marcas = csvMarcas.GetRecords<Marca>();
                    context.Marcas.AddRange(marcas);
                    await context.SaveChangesAsync();
                }
            }
        }

        if (!context.Categorias.Any())
        {
            using (var readerCategorias = new StreamReader(ruta + @"/Data/Csvs/categorias.csv"))
            {
                using (var csvCategorias = new CsvReader(readerCategorias, CultureInfo.InvariantCulture))
                {
                    var categorias = csvCategorias.GetRecords<Categoria>();
                    context.Categorias.AddRange(categorias);
                    await context.SaveChangesAsync();
                }
            }
        }

        if (!context.Productos.Any())
        {
            using (var readerProductos = new StreamReader(ruta + @"/Data/Csvs/productos.csv"))
            {
                using (var csvProductos = new CsvReader(readerProductos, CultureInfo.InvariantCulture))
                {
                    var listadoProductosCsv = csvProductos.GetRecords<Producto>();

                    List<Producto> productos = new List<Producto>();
                    foreach (var item in listadoProductosCsv)
                    {
                        productos.Add(new Producto
                        {
                            Id = item.Id,
                            Nombre = item.Nombre,
                            Precio = item.Precio,
                            FechaCreacion = item.FechaCreacion,
                            CategoriaIdFk = item.CategoriaIdFk,
                            MarcaIdFk = item.MarcaIdFk                        
                        });
                    }

                    context.Productos.AddRange(productos);
                    await context.SaveChangesAsync();
                }
            }
        }


    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<JwtDemoContext>();
        logger.LogError(ex.Message);
    }
}

public static async Task SeedRolesAsync(JwtDemoContext context, ILoggerFactory loggerFactory)
{
    try
    {
        if (!context.Rols.Any())
        {
            var roles = new List<Rol>()
                    {
                        new Rol{Id=1, Nombre="Aministrator"},
                        new Rol{Id=2, Nombre="Customer"},
                        new Rol{Id=3, Nombre="Employee"},
                    };
            context.Rols.AddRange(roles);
            await context.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<JwtDemoContext>();
        logger.LogError(ex.Message);
    }
}
}