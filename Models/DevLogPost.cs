namespace ProjectBunkerWebApi.Models;

public class DevLogPost
{
    //Id and title
    public int Id { get; set; }
    public string Title { get; set; }
    
    //Relations
    public List<DevLogCategory> Categories { get; set; } = new();
    public List<DevLogComment> Comments { get; set; } = new();
    public List<DevLogLike> Likes { get; set; } = new();
    
    //Content
    public string Content { get; set; }
    
    //Author
    public int AuthorId { get; set; }
    public User Author { get; set; } // we want a user to be associated with a post
    
    
    public DateTime CreatedAt { get; set; }
    
    //Modifications
    public bool Modified => CreatedAt != LastModified;
    public bool Active { get; set; }
    public DateTime LastModified { get; set; }
}