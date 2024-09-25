using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BOL;
using BAL;
using MongoDB.Bson;

namespace InvoiceMGTCoreMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBAL _productBAL;

        public ProductsController(IProductBAL productBAL)
        { 
            _productBAL = productBAL;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<ProductObj>> GetAll()
        {
            try
            {

                var products = await _productBAL.GetAllAsync();     
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<ProductObj>> GetById(string id)
        {
            try
            {
                var product = await _productBAL.GetByIdAsync(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult> Create(ProductObj product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    product.Id = ObjectId.GenerateNewId().ToString();  // Generate a new ObjectId if not provided
                }

                var result = await _productBAL.CreateAsync(product);
                return CreatedAtAction(nameof(GetById), new {id = product.Id }, product);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(string id, ProductObj product)
        {
            try
            {
                var productFind = await _productBAL.GetByIdAsync(id);
                if(productFind == null) return NotFound();
                var result = await _productBAL.UpdateAsync(id,product);
                return CreatedAtAction(nameof(GetById), new {id=product.Id }, product);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var productFind = await _productBAL.GetByIdAsync(id);
                if(productFind == null) return NotFound();
                var result = await _productBAL.DeleteAsync(id);
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}
