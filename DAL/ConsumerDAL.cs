using BOL;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConsumerDAL:IConsumerDAL
    {
		private readonly IMongoCollection<TaskMessage> _taskCollection;

		public ConsumerDAL(IOptions<MongoDbSettings> mongoDbSettings)
		{
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _taskCollection = database.GetCollection<TaskMessage>(mongoDbSettings.Value.ProductCollection);

            //_taskCollection = databse.GetCollection<TaskMessage>("TaskMessages");
		}
       public async Task<bool> StartConsumingAsync(CancellationToken cancellationToken)
        {
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					var filter = Builders<TaskMessage>.Filter.Eq(t => t.Status, "Pending");
					var taskMessage = await _taskCollection.Find(filter).FirstOrDefaultAsync();
					if (taskMessage != null)
					{
						Console.WriteLine("Processing task with id : {taskMessage.Id} and payload: {taskMessage.Payload}");

						//Simulate task processing 
						await ProcessTask(taskMessage);

						//Mark the task as processed 
						var update = Builders<TaskMessage>.Update.Set(t => t.Status, "Processed");
						await _taskCollection.UpdateOneAsync(t=>t.Id == taskMessage.Id, update);

					}
					//Sleep for a while before polling again
					await Task.Delay(5000);   //pull every 5 seconds

				}
			}
			catch (Exception ex)
			{

				throw;
			}
            return true;
        }

		private async Task ProcessTask(TaskMessage taskMessage)
		{
			await Task.Delay(2000);
			Console.WriteLine($"Task with Id : {taskMessage.Id} has been processed");
		}
    }
}
