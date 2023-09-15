namespace ApiJWT.Dtos;

public class ProdcutoListDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int MarcaIdFk { get; set; }
    public string Marca { get; set; }
    public int CategoriaIdFk { get; set; }  
    public string Categoria { get; set; }
}
