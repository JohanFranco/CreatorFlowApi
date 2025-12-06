using CreatorFlowApi.DTOs.Auth;

namespace CreatorFlowApi.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto> LoginAsync(LoginUserDto dto);
    }
}
