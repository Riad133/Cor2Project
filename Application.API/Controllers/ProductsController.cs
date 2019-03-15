using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ProductHelper.GetProducts());
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(ProductHelper.GetProduct(id));
        }

        /// <summary>
        /// Creates a Product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "description": "Description"
        ///     }
        /// </remarks>
        /// <param name="product"></param>
        /// <returns>A newly created product</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return Ok(ProductHelper.AddProduct(product));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(ProductHelper.Update(id, product));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(ProductHelper.DeleteProduct(id));
        }

      
    }
}
