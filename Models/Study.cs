using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TattooBackend.Models;
public class Study{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID {get;set;}
    public string? Name {get;set;}
    public string? Latitude {get;set;}
    public string? Longitude {get;set;}
}