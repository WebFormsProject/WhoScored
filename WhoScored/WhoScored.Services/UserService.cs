using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class UserService : IUserService
    {
        private readonly IWhoScoredContext context;
        private readonly IWhoScoredRepository<User> userRepository;

        public UserService(IWhoScoredContext context, IWhoScoredRepository<User> userRepository)
        {
            Guard.WhenArgument(userRepository, "userRepository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
            this.userRepository = userRepository;
        }

        public User GetUserById(object id)
        {
            return this.userRepository.GetById(id);
        }

        public string GetAvatarFilePath(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            return this.userRepository.GetById(userId).AvatarPath;
        }

        public void UploadAvatar(string userId, string filePath)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(filePath, "filePath").IsNull().Throw();

            User user = this.userRepository.GetById(userId);
            if (user != null)
            {
                user.AvatarPath = filePath;
                this.context.SaveChanges();
            }
        }
    }
}
