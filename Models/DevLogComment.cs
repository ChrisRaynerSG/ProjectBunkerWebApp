namespace ProjectBunkerWebApi.Models;

public class DevLogComment
{
    public int Id { get; set; }
    public string Content { get; set; }
    
    public int AuthorId { get; set; }
    public User Author { get; set; }
    
    public List<DevLogCommentLike> Likes { get; set; } = new();
    
    public int PostId { get; set; }
    public DevLogPost Post { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool Active { get; set; }
    public bool Modified => CreatedAt != LastModified;
    public DateTime LastModified { get; set; }
}