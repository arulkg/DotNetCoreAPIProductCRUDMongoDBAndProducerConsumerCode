using MongoDB.Driver;
using BOL;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;


namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        private readonly IMongoCollection<ProductObj> _products;

        public ProductDAL(IOptions<MongoDbSettings> mongoDbSettings)
        { 
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _products = database.GetCollection<ProductObj>(mongoDbSettings.Value.ProductCollection);

        }

        public async Task<List<ProductObj>> GetAllAsync()
        {
            try
            {
                var products = await _products.Find(_ => true).ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ProductObj> GetByIdAsync(string id)
        {
            try
            {
                var product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
            
        public async Task<bool> CreateAsync(ProductObj productObj)
        {
            try
            {
                
                await _products.InsertOneAsync(productObj);
                return true;
            }
            catch (global::System.Exception ex)
            {

                throw;
            }
        }


       public async Task<bool> UpdateAsync(string id, ProductObj productObj) {
            try
            {
                await _products.ReplaceOneAsync(p => p.Id == id, productObj);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                await _products.DeleteOneAsync(p => p.Id == id);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        } 
            
    }
}
