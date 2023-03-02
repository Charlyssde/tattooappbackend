using System.Text.Json.Serialization;
using TattooBackend.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TattooBackend.Models;

public class Profile 
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID {get; set;}
    public string? Name {get;set;}
    public string? Path {get;set;}
    public string? Resume {get;set;}

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly BirthDay {get;set;}
    public string? Phone {get;set;}
    public string? Email {get;set;}
    public long CompleteProfile {get;set;}
    public string? UserId {get;set;}
}