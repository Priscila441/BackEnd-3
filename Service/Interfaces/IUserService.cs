
using Models.Entity.Dtos.User;

namespace Service.Interfaces
{
    public interface IUserService
    {
        
        Task<IEnumerable<UserGetDto>> BringAllAsync();
        Task<UserGetDto> BringOneAsync(int id);
        Task<UserGetDto> CreateAsync(UserPostDto dto);
        Task<bool> ChangeAsync(int id, UserPutDto dto);
        Task<bool> DeleteAsync(int id);

        Task<UserGetDto?> ValidateUserAsync(string email, string password);


    }
}
