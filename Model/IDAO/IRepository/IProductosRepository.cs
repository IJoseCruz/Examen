using Examen.Model.DTO;
using Examen.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Model.IDAO.IRepository
{
    public interface IProductosRepository
    {
        Task<List<Productos>> GetProductos();
        Task<Productos> GetProductoByIdAsync(int id);

        Task<IActionResult> AddProductoAsync(Productos entity);

        Task<IActionResult> UpdateProductoAsync(RequestProducto producto, Productos productos);

        Task<IActionResult> DeleteProductoByIdAsync(int id);
    }
}
