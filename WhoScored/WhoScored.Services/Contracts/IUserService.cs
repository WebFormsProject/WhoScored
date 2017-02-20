using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(object id);
    }
}
