using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Interfaces.Product;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Implementation
{
    public class ProductService : EntityService<Product, ChangeProductDto>, IProductService
    {
        public ProductService(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task DeleteAllAsync(DeleteAllDto deleteAllDto)
        {
            using (var transacation = DbContext.BeginTransaction())
            {
                var tasks = deleteAllDto.Ids.Select(async x => await DeleteAsync(x));
                await transacation.CommitAsync();
            }

        }
    }
}
