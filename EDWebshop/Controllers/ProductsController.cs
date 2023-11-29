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
        public async Task<ActionResult<IEnumerable<FlowerProductListDto>>> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productsDto = _mapper.Map<List<FlowerProductListDto>>(products.ToList());

            return Ok(productsDto);
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

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _repository.GetAsync(id);

            if (product is null)
                return NotFound();

            await _repository.DeleteAsync(product);

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, [FromBody] FlowerProductDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest("Id stämmer inte överens med id i body.");

            var product = await _repository.GetAsync(id);

            if (product is null)
                return NotFound();

            var updatedProduct = _mapper.Map(productDto, product);

            await _repository.UpdateAsync(updatedProduct);

            return NoContent();
        }
    }
}