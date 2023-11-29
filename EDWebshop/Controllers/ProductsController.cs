using AutoMapper;
using EDWebshop.Contracts.DTOs;
using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EDWebshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IRepository<FlowerProduct> repository, IMapper mapper) : ControllerBase
    {
        private readonly IRepository<FlowerProduct> _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FlowerProductsDto>>> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productsDto = _mapper.Map<List<FlowerProductsDto>>(products.ToList());

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlowerProductDto>> Get(int id)
        {
            var product = await _repository.GetAsync(id);

            if (product is null)
                return NotFound();

            var productDto = _mapper.Map<FlowerProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FlowerProductDto>> Create([FromBody] FlowerProductDto productDto)
        {
            var product = _mapper.Map<FlowerProduct>(productDto);

            if (product.Id != 0)
                return BadRequest("Id måste vara 0.");

            var createdProduct = await _repository.CreateAsync(product);

            var createdProductDto = _mapper.Map<FlowerProductDto>(createdProduct);

            return CreatedAtAction(nameof(Get), new { id = createdProductDto.Id }, createdProductDto);
        }
    }
}