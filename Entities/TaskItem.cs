namespace CreatorFlowApi.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int ContentItemId { get; set; }
        public ContentItem ContentItem { get; set; } = null!;
        public string Title { get; set; } = null!;
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

    }

}
