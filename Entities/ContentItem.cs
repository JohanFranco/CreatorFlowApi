namespace CreatorFlowApi.Entities
{
    public class ContentItem
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Type { get; set; } = "video";
        public string Status { get; set; } = "idea";
        public DateTime? PlannedDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string? PublishedUrl { get; set; }
        public List<TaskItem> Tasks { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

    }


}
