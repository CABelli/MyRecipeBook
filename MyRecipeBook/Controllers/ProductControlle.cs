using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MyRecipeBook.Dto;
using MyRecipeBook.InfraMongodb.InterfaceContext;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductController(IProductRepository productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProdAll()
        {
            var products = await _productRepository.GetAll();

            return Ok(products);
        }

        [HttpGet]
        [Route("get-id")]
        public async Task<ActionResult<Product>> GetProdId(string id)
        {
            var product = await _productRepository.GetById(id);

            return Ok(product);
        }

        [HttpGet]
        [Route("get-name")]
        public async Task<ActionResult<Product>> GetProdName(string nameProduct)
        {
            var product = await _productRepository.GetByName(nameProduct);

            return Ok(product);
        }

        [HttpPost]
        [Route("post-add")]
        public async Task<ActionResult<Product>> Post([FromBody] ProductDto NameProduct)
        {
            //var product = new Product(NameProduct.NameProduct)
            var newId = ObjectId.GenerateNewId().ToString();

            var product = new Product { Id = newId, NameProduct = NameProduct.NameProduct };

            _productRepository.Add(product);

            // it will be null
                  
            //var testProduct = await _productRepository.GetById(Guid.Parse(product.Id));

            // If everything is ok then:

               // await _uow.Commit();

            // The product will be added only after commit
            //testProduct = await _productRepository.GetById(product.Id);

            return Ok("Show"); //testProduct);
        }

        [HttpPut]
        [Route("put-update")]
        public async Task<IActionResult> UpdateProduct([FromBody] string nameProduct)
        {
            var product = await _productRepository.GetByName(nameProduct);

            var tmp = new Product () { Id = "647777af0f615394bc74891b", NameProduct = "UVa" };

            _productRepository.UpdateObj(tmp); // product);

            return Ok("Show");
        }

        //[HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProductById(string nameProduct)
        {
            var product = await _productRepository.GetByName(nameProduct);

             _productRepository.RemoveObj(product.Id);

            return Ok("Show");
        }
    }
}
