namespace Examen.Model.Entities
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
