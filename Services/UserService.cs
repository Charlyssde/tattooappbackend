using TattooBackend.Models;
using TattooBackend.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TattooBackend.Services;

public class UserService
{
    private readonly IMongoCollection<User> _collection;

    public UserService(
        IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<List<User>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
        await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _collection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _collection.ReplaceOneAsync(x => x.ID == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.ID == id);
}