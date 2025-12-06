using CreatorFlowApi.Data;
using CreatorFlowApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreatorFlowApi.Repositories.Users
{
    public class UserRepository
    {
        private readonly CreatorFlowDbContext _context;

        public UserRepository(CreatorFlowDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
