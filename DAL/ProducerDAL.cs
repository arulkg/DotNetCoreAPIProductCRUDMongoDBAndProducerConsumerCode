using BOL;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace DAL
{
    public class ProducerDAL:IProducerDAL
	{
		private readonly IMongoCollection<TaskMessage> _taskMessages;

		public ProducerDAL(IOptions<MongoDbSettings> mongoDbSettings)
		{
			var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
			var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _taskMessages = database.GetCollection<TaskMessage>(mongoDbSettings.Value.ProductCollection);
		}

		public async Task<bool> Insert(TaskMessage payload)
        {
			try
			{
				await _taskMessages.InsertOneAsync(payload);
				return true;
			}
			catch (Exception ex)
			{

				throw;
			}
        }

    }
}
