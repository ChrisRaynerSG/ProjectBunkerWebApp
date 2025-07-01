using System.ComponentModel.DataAnnotations;

namespace ProjectBunkerWebApi.Models;

public class User
{
    //Id
    public int Id { get; set; }
    
    //Account details
    [Required]
    [StringLength(30,MinimumLength = 3)]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    // Modifiers
    public bool Active { get; set; }
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime LastModified { get; set; }
    
    //Relationships
    public List<DevLogPost> Posts { get; set; }
    public List<DevLogComment> Comments { get; set; }
    public List<DevLogLike> PostLikes { get; set; }
    public List<DevLogCommentLike> CommentLikes { get; set; }
    
}