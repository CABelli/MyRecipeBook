using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Dto;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Model;
using MyRecipeBook.InfraSqlServer.InterfaceRepository;
using MyRecipeBook.InfraSqlServer.Model;
using System.Collections;
using System.Collections.Generic;

namespace MyRecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceProductClientController : ControllerBase
    {
        private readonly IPriceProductClientRepository _priceProductClientRepository;
        private readonly IProductRepository _productRepository;

        public PriceProductClientController(IPriceProductClientRepository priceProductClientRepository,
            IProductRepository productRepository)
        {
            _priceProductClientRepository = priceProductClientRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("get-list")]
        //public async Task<ActionResult<PriceProductClient>> Get(string titleRecipe) => Ok(await _priceProductClientRepository.GetAllPrice(titleRecipe));
        public async Task<ActionResult<IEnumerable<PriceProductClientGetAllDto>>> GetAllPricies(string titleRecipe)
        {
            var priceProductClients = await _priceProductClientRepository.GetAllPrice02(titleRecipe);
                //.GetAllPrice(titleRecipe);
            
            if (priceProductClients == null) return NotFound("Not easy");

            
            var priceProductClientListDTO = new PriceProductClientGetAllDto()
            {
            };

            IEnumerable x = PriceProductClientGetAllDto();

            foreach ( var priceProductClient in priceProductClients)
            {
                var product = await _productRepository.GetByName(titleRecipe);
                new PriceProductClientGetAllDto()
                {
                    NameProduct = product.NameProduct,
                    ProductValue = priceProductClient.ProductValue

                };

                priceProductClientListDTO.ad
            }


            return priceProductClientListDTO;
        }

        [HttpPost]
        [Route("post-add")]
        public async Task<ActionResult> IncludePriceProductClient([FromBody] PriceProductClientAddDto priceProdCliAddDto)
        {
            var product = await _productRepository.GetByName(priceProdCliAddDto.NameProduct);

            if (product == null) return BadRequest("Produto não cadastrado!!!");

            var priceProductClient = new PriceProductClient()
            {
                ProductValue = priceProdCliAddDto.ProductValue,
                DateValidate = priceProdCliAddDto.DateValidate,
                IdProduct = product.Id
            };

            await _priceProductClientRepository.AddPriceProductClient(priceProductClient);

            return Ok("Include= Sucesso !!-!!"); // CreatedAtAction("Include= ","Sucesso !!-!!");
        }
    }
}
