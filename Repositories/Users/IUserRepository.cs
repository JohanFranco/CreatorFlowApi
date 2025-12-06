using CreatorFlowApi.Entities;

namespace CreatorFlowApi.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}
