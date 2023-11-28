using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EDWebshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<FlowerProduct> _repository;
    }
}
