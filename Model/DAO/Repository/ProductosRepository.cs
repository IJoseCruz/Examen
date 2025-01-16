using Examen.Model.DTO;
using Examen.Model.Entities;
using Examen.Model.IDAO.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Examen.Model.DAO.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly AppDbContext _dbProductos;

        public ProductosRepository(AppDbContext dbProductos)
        {
            _dbProductos = dbProductos ?? throw new ArgumentNullException(nameof(dbProductos));
        }
        public async Task<List<Productos>> GetProductos()
        {
            var response = await _dbProductos.Productos.ToListAsync();

            return response;

        }
        public async Task<Productos> GetProductoByIdAsync(int id)
        {
            var response = await _dbProductos.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if(response is null)
            {
                return null!;
            }
            return response;
        }

        public async Task<IActionResult> AddProductoAsync(Productos producto)
        {
            _dbProductos.Productos.Add(producto);
            await _dbProductos.SaveChangesAsync();


            return new CreatedAtActionResult("Producto/id","ProductosController", new { id = producto.Id }, producto);
        }

        public async Task<IActionResult> DeleteProductoByIdAsync(int id)
        {
            var producto = await _dbProductos.Productos.FindAsync(id);

            _dbProductos.Productos.Remove(producto);
            await _dbProductos.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<IActionResult> UpdateProductoAsync(RequestProducto producto, Productos productoEntity)
        {
            productoEntity.Nombre = producto.Nombre;
            productoEntity.Precio = producto.Precio;
            productoEntity.Descripcion = producto.Description;
            productoEntity.CantidadStock = producto.CantidadStock;

            await _dbProductos.SaveChangesAsync();


            return new ObjectResult(productoEntity) { StatusCode = 200 };
        }
    }
}
