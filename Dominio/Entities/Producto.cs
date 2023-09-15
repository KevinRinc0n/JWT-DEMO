namespace Dominio.Entities;

public class Producto : BaseEntity
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int MarcaIdFk { get; set; }
    public Marca Marca { get; set; }
    public int CategoriaIdFk { get; set; }
    public Categoria Categoria { get; set; }
}