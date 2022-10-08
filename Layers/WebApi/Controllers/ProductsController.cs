using Layers.ApplicationServices.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IReadOnlyProductService _readOnlyProductService;

        public ProductsController(IProductService productService, IReadOnlyProductService readOnlyProductService)
        {
            _productService = productService;
            _readOnlyProductService = readOnlyProductService;
        }

        [HttpGet("{id}")]
        public Task<ProductDto> GetByIdAsync(int id)
        {
            return _readOnlyProductService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeProductDto dto)
        {
            return _productService.CreateAsync(dto);
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeProductDto dto)
        {
            return _productService.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(int id)
        {
            return _productService.DeleteAsync(id);
        }

        [HttpDelete]
        public Task DeleteAllAsync([FromBody] DeleteAllDto deleteAllDto)
        {
            return _productService.DeleteAllAsync(deleteAllDto);
        }

    }
}
