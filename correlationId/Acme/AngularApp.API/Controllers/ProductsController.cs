using System.Linq;
using AngularApp.API.Models;
using AngularApp.API.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Products Controller
/// </summary>
namespace AngularApp.API.Controller
{
    /// <summary>
    /// Products Controller 
    /// </summary>
    [Route("api/[controller]")]
    public class ProductsController : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// The products repository
        /// </summary>
        private readonly IProductsRepository _productsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductsController(IProductsRepository productRepository)
        {
            _productsRepository = productRepository;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productsRepository.GetAll());
        }

        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Adds a product</returns>
        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product newProduct = _productsRepository.Add(product);

            return CreatedAtRoute("GetSingleThing", new { id = newProduct.ProductId }, newProduct);
        }

        /// <summary>
        /// Partiallies the update.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patchDoc">The patch document.</param>
        /// <returns>Updated Product</returns>
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            Product existingEntity = _productsRepository.GetSingle(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            Product product = existingEntity;
            patchDoc.ApplyTo(product, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedThing = _productsRepository.Update(id, product);

            return Ok(updatedThing);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            Product product = _productsRepository.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            _productsRepository.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>Product item.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]Product product)
        {
            var thingToCheck = _productsRepository.GetSingle(id);

            if (thingToCheck == null)
            {
                return NotFound();
            }

            if (id != product.ProductId)
            {
                return BadRequest("Ids do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedThing = _productsRepository.Update(id, product);

            return Ok(updatedThing);
        }
    }
}
