using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Interfaces.Product;

namespace Layers.ApplicationServices.Implementation
{
    public class ReadOnlyProductService : ReadOnlyEntityService<Product, ProductDto>, IReadOnlyProductService
    {
        public ReadOnlyProductService(IReadOnlyDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

    }
}
