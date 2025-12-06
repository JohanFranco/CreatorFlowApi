using CreatorFlowApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreatorFlowApi.Data
{
    public class CreatorFlowDbContext: DbContext
    {

        public CreatorFlowDbContext(DbContextOptions<CreatorFlowDbContext> options) : base()
        {
            
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ContentItem> ContentItems => Set<ContentItem>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    }
}
