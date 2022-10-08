using CQ.CqrsFramework;
using Handlers.UseCases.Order.Commands.UpdateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : DeleteEntityCommand ,ICommand
    {

    }
}
