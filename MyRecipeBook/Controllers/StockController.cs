using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MyRecipeBook.Dto;
using MyRecipeBook.InfraMongodb.InterfaceContext;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.Controllers
{
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public StockController(IStockRepository stockRepository, IUnitOfWork uow, IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _uow = uow;
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("post-add")]
        public async Task<ActionResult<Product>> Post([FromBody] StockInDto stockInDto)
        {
            var product = await _productRepository.GetByName(stockInDto.NameProduct);

            var newId = ObjectId.GenerateNewId().ToString();

            var stock = new Stock { Id = newId, 
                IdProduct = product.Id, 
                DescriptionStock = stockInDto.DescriptionStock,
                QuantityAvailable = stockInDto.QuantityAvailable,
                QuantityUsed = stockInDto.QuantityUsed
            };

            _stockRepository.Add(stock);

            return Ok("Show");
        }
    }
}
