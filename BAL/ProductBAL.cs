using BOL;
using DAL;
using System.Runtime.CompilerServices;



namespace BAL
{
    public class ProductBAL:IProductBAL
    {
        private readonly IProductDAL _productDAL;

        public ProductBAL(IProductDAL productDAL)
        { 
            _productDAL = productDAL;
        }

        public async Task<List<ProductObj>> GetAllAsync()
        {
            return await _productDAL.GetAllAsync();

        }
        public async Task<ProductObj> GetByIdAsync(string id)
        { 
            return await _productDAL.GetByIdAsync(id);
        }
        public async Task<bool> CreateAsync(ProductObj productObj)
        { 
            return await _productDAL.CreateAsync(productObj);
        }
        public async Task<bool> UpdateAsync(string id, ProductObj productObj)
        { 
             return await _productDAL.UpdateAsync(id, productObj);
        }
        public async Task<bool> DeleteAsync(string id)
        { 
            return await _productDAL.DeleteAsync(id);
        }


    }
}
