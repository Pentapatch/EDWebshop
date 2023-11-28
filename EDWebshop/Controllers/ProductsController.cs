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
        public async Task<ActionResult<IEnumerable<FlowerProductsDto>>> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productsDto = _mapper.Map<List<FlowerProductsDto>>(products.ToList());

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FlowerProductDto>> Get(int id)
        {
            var product = await _repository.GetAsync(id);

            var productDto = _mapper.Map<FlowerProductDto>(product);

            return Ok(productDto);
        }
    }
}