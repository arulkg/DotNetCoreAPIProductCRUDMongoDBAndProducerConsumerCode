using BOL;


namespace BAL
{
    public interface IProductBAL
    {
        Task<List<ProductObj>> GetAllAsync();
        Task<ProductObj> GetByIdAsync(string id);
        Task<bool> CreateAsync(ProductObj productObj);
        Task<bool> UpdateAsync(string id, ProductObj productObj);
        Task<bool> DeleteAsync(string id);
    }
}
