using Examen.Model.DTO;
using Examen.Model.DTO.Validations;
using Examen.Model.IDAO.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _service;
        private readonly RequestProductosValidator _requestCreateValidator;
         public ProductosController(IProductosService service, RequestProductosValidator requestCreateValidator)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _requestCreateValidator = requestCreateValidator ?? throw new ArgumentNullException(nameof(requestCreateValidator));
        }
        [HttpGet("Productos")]
        public async Task<IActionResult> Productos()
        {
            try
            {
                


                var result = await _service.GetProductos();
                if (result is null)
                {
                    return Ok(
                        "No se encontraron resultados"
                    );
                }
                return Ok(result);
            }
            catch (Exception _e)
            {
                return BadRequest(
                    
                );
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById([FromRoute] int id)
        {
            try
            {
                var result = await _service.GetPruductoById(id);
                if (result is null)
                {
                    return Ok(
                       "No se encontro el producto"
                    );
                }
                return Ok(result);
            }
            catch (Exception _e)
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(
            RequestProducto request
        )
        {
            try
            {
                var validationResult = _requestCreateValidator.Validate(request);
                if (!validationResult.IsValid) 
                {
                    return Ok(validationResult.ToString());
                }
                var result = await _service.AddProducto(request);
                return Ok(result);
            }
            catch (Exception _e)
            {
                return BadRequest("Ha ocurrido algún error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entityExist = await _service.GetPruductoById(id);
            if(entityExist is null)
            {
                return NotFound($"El producto con el id {id} no existe.");
            }
            
            var result = await _service.DeleteProductoById(id);
            return Ok("Se ha elimitado el producto");
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, RequestProducto productoRequest)
        {
            var validationResult = _requestCreateValidator.Validate(productoRequest);
            if (!validationResult.IsValid)
            {
                return Ok(validationResult.ToString());
            }
            var entityExist = await _service.GetPruductoById(id);
            if (entityExist is null)
            {
                return NotFound($"El producto con el id {id} no existe.");
            }

            var result = await _service.UpdateProducto(productoRequest,  entityExist);
            return Ok(result);


        }
    }
}
