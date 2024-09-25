using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IProducerBAL
    {
        Task<bool> Insert(TaskMessage payload);
    }
}
