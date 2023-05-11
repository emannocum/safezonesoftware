using safezonesoftware_restapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace safezonesoftware_restapi.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            try
            {
                MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
                IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
                _usersCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database:");
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to indicate a problem with the database connection
            }
            
        }

        public async Task CreateAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return;
        }

        public async Task<List<User>> GetAsync() {
            try
            {
                return await _usersCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving data from the database:");
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to indicate a problem with retrieving data
            }
        }

        public async Task UpdateAsync(string id, string users)
        {
            FilterDefinition<User> filterDefinition = Builders<User>.Filter.Eq("Id", id);
            UpdateDefinition<User> updateDefinition = Builders<User>.Update.AddToSet<string>(id, users);
            await _usersCollection.UpdateOneAsync(filterDefinition, updateDefinition);
            return;
        }
        
    }
}
 