using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class UserService : IUserService
    {
        private readonly IWhoScoredRepository<User> useRepository;

        public UserService(IWhoScoredRepository<User> useRepository)
        {
            Guard.WhenArgument(useRepository, "useRepository").IsNull().Throw();

            this.useRepository = useRepository;
        }

        public User GetUserById(object id)
        {
            return this.useRepository.GetById(id);
        }
    }
}
