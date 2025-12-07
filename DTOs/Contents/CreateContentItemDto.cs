namespace CreatorFlowApi.DTOs.Contents
{
    public class CreateContentItemDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Type { get; set; } = "video";
        public string Status { get; set; } = "idea";
        public DateTime? PlannedDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string? PublishedUrl { get; set; }
    }
}
