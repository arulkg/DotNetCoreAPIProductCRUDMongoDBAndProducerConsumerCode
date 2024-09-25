using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Threading;

namespace DAL
{
    public interface IProductDAL
    {
       Task<List<ProductObj>> GetAllAsync();
       Task<ProductObj> GetByIdAsync(string id);
       Task<bool> CreateAsync(ProductObj productObj);
       Task<bool> UpdateAsync(string id, ProductObj productObj);
       Task<bool> DeleteAsync(string id);
    }
}
