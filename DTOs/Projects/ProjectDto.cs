using CreatorFlowApi.Entities;

namespace CreatorFlowApi.DTOs.Projects
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Platform { get; set; } = "YouTube"; // Twitch, TikTok, etc.
        public bool IsActive { get; set; } = true;
        public List<ContentItem> ContentItems { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
