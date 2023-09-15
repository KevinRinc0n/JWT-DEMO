using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Dtos;

public class ProductoAddUpdateDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre del producto es requerido")]
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int MarcaIdFk { get; set; }
    public int CategoriaIdFk { get; set; } 
}
