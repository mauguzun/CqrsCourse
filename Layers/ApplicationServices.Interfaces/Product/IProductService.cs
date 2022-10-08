using ApplicationServices.Interfaces;
using System.Threading.Tasks;

namespace Layers.ApplicationServices.Interfaces.Product
{
    public interface IProductService : IEntityService<ChangeProductDto>
    {
        Task DeleteAllAsync(DeleteAllDto deleteAllDto);
    }
}
