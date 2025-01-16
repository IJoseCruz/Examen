namespace Examen.Model.DTO
{
    public class RequestProducto
    {
        public string Nombre { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
    }
}
