using Examen.Model.DTO;
using Examen.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Model.IDAO.IServices
{
    public interface IProductosService
    {
        Task<List<Productos>> GetProductos();
        Task<Productos> GetPruductoById(int id);
        Task<IActionResult> AddProducto(RequestProducto productos);
        Task<IActionResult> DeleteProductoById(int id);
        Task<IActionResult> UpdateProducto(RequestProducto producto, Productos productos);
    }
}
