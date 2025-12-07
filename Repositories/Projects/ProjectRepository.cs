using CreatorFlowApi.Data;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories.Contents;
using CreatorFlowApi.Repositories.Users;
using Microsoft.EntityFrameworkCore;


namespace CreatorFlowApi.Repositories.Projects
{
    public class ContentItemRepository : Repository<ContentItem>, IContentItemRepository
    {
        private readonly CreatorFlowDbContext _context;

        public ContentItemRepository(CreatorFlowDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContentItem>> GetScheduleAsync(int userId, DateTime from, DateTime to)
        {
            return await _context.ContentItems
                .Include(ci => ci.Project) // Necesario para validar UserId
                .Where(ci =>
                    ci.PlannedDate != null &&
                    ci.PlannedDate >= from &&
                    ci.PlannedDate <= to &&
                    ci.Project.UserId == userId)
                .OrderBy(ci => ci.PlannedDate)
                .ToListAsync();
        }
    }
}
