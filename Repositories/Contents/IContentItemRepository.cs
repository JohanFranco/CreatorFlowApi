using CreatorFlowApi.Entities;

namespace CreatorFlowApi.Repositories.Contents
{
    public interface IContentItemRepository: IRepository<ContentItem>
    {
        Task<IEnumerable<ContentItem>> GetScheduleAsync(int userId, DateTime from, DateTime to);
    }
}
