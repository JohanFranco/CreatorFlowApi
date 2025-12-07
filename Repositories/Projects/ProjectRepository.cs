using CreatorFlowApi.Data;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories.Users;
using Microsoft.EntityFrameworkCore;


namespace CreatorFlowApi.Repositories.Projects
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly CreatorFlowDbContext _context;

        public ProjectRepository(CreatorFlowDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Project?> GetProjectWithContentAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.ContentItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
