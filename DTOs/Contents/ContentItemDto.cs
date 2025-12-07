using CreatorFlowApi.Entities;

namespace CreatorFlowApi.DTOs.Contents
{
    public class ContentItemDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? PlannedDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string? PublishedUrl { get; set; }
    }
}
