using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConsumerDAL
    {
        Task<bool> StartConsumingAsync(CancellationToken cancellationToken);

    }
}
