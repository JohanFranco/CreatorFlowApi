namespace CreatorFlowApi.DTOs.Projects
{
     public class UpdateProjectDto
     {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Platform { get; set; } = "YouTube";
        public bool IsActive { get; set; } = true;
     }
}
