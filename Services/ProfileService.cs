using TattooBackend.Models;
using TattooBackend.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TattooBackend.Services;

public class ProfileService {
    private readonly IMongoCollection<Profile> _collection;

    public ProfileService (IOptions<DatabaseSettings> databaseSettings){
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Profile>("Profile");
    }

    public async Task<List<Profile>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Profile?> GetAsync(string id) =>
        await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();

    public async Task<Profile> GetByUser(string id) => 
        await _collection.Find(x => x.UserId == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Profile newProfile) =>
        await _collection.InsertOneAsync(newProfile);

    public async Task UpdateAsync(string id, Profile updatedProfile) =>
        await _collection.ReplaceOneAsync(x => x.ID == id, updatedProfile);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.ID == id);

}