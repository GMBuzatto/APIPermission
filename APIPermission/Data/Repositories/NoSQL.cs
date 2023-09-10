using APIPermission.Data.Configurations;

using MongoDB.Driver;
using Task = APIPermission.Models.Task;

namespace APIPermission.Data.Repositories
{
    public class NoSQL : INoSQL
    {
        private readonly IMongoCollection<Task> _taskCollections;

        public NoSQL(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
     
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _taskCollections = database.GetCollection<Task>("tasks");
        }

        public void Add(Task task)
        {
            _taskCollections.InsertOne(task);
        }

        public void Update(string id, Task taskUpdated)
        {
            _taskCollections.ReplaceOne(task => task.Id == id, taskUpdated);
        }

        public IEnumerable<Task> Get()
        {
            return _taskCollections.Find(task => true).ToList();
        }

        public Task Get(string id)
        {
            return _taskCollections.Find(task => task.Id == id).FirstOrDefault();
        }

        public void Delete(string id)
        {
            _taskCollections.DeleteOne(task => task.Id == id);
        }

    }
}
