using CreatorFlowApi.Entities;

namespace CreatorFlowApi.Repositories.Projects
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetProjectWithContentAsync(int id);
    }
}
