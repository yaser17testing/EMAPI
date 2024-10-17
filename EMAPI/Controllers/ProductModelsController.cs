using EMAPI.Data;
using EMAPI.Dto;
using EMAPI.Models;
using EMAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelsController : ControllerBase
    {



        private readonly DataContext dataContext;
        private readonly IProduct productRepo;


        public ProductModelsController(DataContext dataContext, IProduct productRepo)
        {
            this.dataContext = dataContext;
            this.productRepo = productRepo;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {



            var productsDomain = await productRepo.GetAllAsync();

            var productsDto = new List<ProductDto>();
            foreach (var productDomain in productsDomain)
            {

                productsDto.Add(new ProductDto()
                {
                    ProductId = productDomain.ProductId,
                    ProductName = productDomain.ProductName,
                    ProductDescription = productDomain.ProductDescription,

                });

            }


            return Ok(productsDto);


        }





        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ProductDto addProductDto)
        {
            var productDomainModel = new ProductModels
            {
                ProductName = addProductDto.ProductName,
                ProductDescription = addProductDto.ProductDescription,


            };




            productDomainModel = await productRepo.CreateAsync(productDomainModel);


            var productDto = new ProductDto
            {
                ProductId = productDomainModel.ProductId,
                ProductName = productDomainModel.ProductName,
                ProductDescription = productDomainModel.ProductDescription,




            };
            return Ok(productDto); /* CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, productDto);*/
        }




        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var productDomain = await productRepo.GetByIdAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }
            var productDto = new ProductDto
            {
                ProductId = productDomain.ProductId,
                ProductName = productDomain.ProductName,
                ProductDescription = productDomain.ProductDescription,

            };
            return Ok(productDto);

        }









    }
}
