using Examen.Model.DTO;
using Examen.Model.Entities;
using Examen.Model.IDAO.IRepository;
using Examen.Model.IDAO.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Model.DAO.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _repository;
        public ProductosService(IProductosRepository repository) { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Productos>> GetProductos()
        {
            var result = await _repository.GetProductos();
            if (result is null)
            {
                return null!;
            }
            return result.ToList();
        }

        public async Task<Productos> GetPruductoById(int id)
        {
            var response = await _repository.GetProductoByIdAsync(id);
            return response;
        }

        public async Task<IActionResult> AddProducto(RequestProducto producto)
        {
            Productos productos = new Productos();
            productos.FechaCreacion = DateTime.Now;
            productos.Precio = producto.Precio;
            productos.Nombre = producto.Nombre;
            productos.Descripcion = producto.Description;
            productos.CantidadStock = producto.CantidadStock;

            var result = await _repository.AddProductoAsync(productos);
            return result;
            
        }

        public async Task<IActionResult> DeleteProductoById(int id)
        {
            try
            {
                var result = await _repository.DeleteProductoByIdAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto", ex);
            }
            
        }

        public async Task<IActionResult> UpdateProducto(RequestProducto producto, Productos productoEntity)
        {
            try
            {
                var result = await _repository.UpdateProductoAsync( producto, productoEntity);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto", ex);
            }
        }

    }
}
