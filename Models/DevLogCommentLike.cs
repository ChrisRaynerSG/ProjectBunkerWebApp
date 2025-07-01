namespace ProjectBunkerWebApi.Models;

public class DevLogCommentLike
{
    public int Id { get; set; }
    
    public int CommentId { get; set; }
    public DevLogComment Comment { get; set; }
    
    public int AuthorId { get; set; }
    public User Author { get; set; }
    
    public DateTime CreatedAt { get; set; }
}