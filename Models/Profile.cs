namespace TattooBackend.Models;

public class Profile 
{
    public long ID {get; set;}
    public string? Name {get;set;}
    public string? Path {get;set;}
    public string? Resume {get;set;}
    public DateOnly BirthDay {get;set;}
    public string? Phone {get;set;}
    public string? Email {get;set;}
    public long CompleteProfile {get;set;}
    public User? UserId {get;set;}
}