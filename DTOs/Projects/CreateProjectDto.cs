namespace CreatorFlowApi.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Platform { get; set; } = "YouTube";
        public DateTime? StartDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
