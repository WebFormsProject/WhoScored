using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class UserAvatarService : IUserAvatarService
    {
        private readonly IWhoScoredContext context;
        private readonly IWhoScoredRepository<User> userRepository;

        public UserAvatarService(IWhoScoredContext context, IWhoScoredRepository<User> userRepository)
        {
            Guard.WhenArgument(userRepository, "userRepository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
            this.userRepository = userRepository;
        }

        public string GetAvatarFilePath(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            return this.userRepository.GetById(userId).AvatarPath;
        }

        public void UploadAvatar(string userId, string avatarFilePath)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(avatarFilePath, "avatarFilePath").IsNull().Throw();

            User user = this.userRepository.GetById(userId);
            if (user != null)
            {
                user.AvatarPath = avatarFilePath;
                this.context.SaveChanges();
            }
        }
    }
}
