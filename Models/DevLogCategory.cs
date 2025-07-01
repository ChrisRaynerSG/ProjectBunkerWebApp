namespace ProjectBunkerWebApi.Models;

public class DevLogCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public DateTime LastModified { get; set; }
    
    public List<DevLogPost> Posts { get; set; } = new();
}