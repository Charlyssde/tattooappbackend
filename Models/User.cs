namespace TattooBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class User {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID {get;set;}
    public string? Username {get;set;}
    public string? Password {get;set;}
    public string? Tipo {get;set;}
}