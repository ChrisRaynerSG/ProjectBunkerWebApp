namespace ProjectBunkerWebApi.Models;

public class DevLogLike
{
    public int Id { get; set; }
    
    public int PostId { get; set; }
    public DevLogPost Post { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int AuthorId { get; set; }
    public User Author { get; set; }
    
}