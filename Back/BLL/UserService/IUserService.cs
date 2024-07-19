using BLL.UserService.Models;

namespace BLL.UserService
{
    public interface IUserService
    {
        User Current { get; }
    }
}
