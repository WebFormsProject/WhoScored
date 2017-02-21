using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWhoScoredRepository<User> userRepository;

        public UserService(IUnitOfWork unitOfWork, IWhoScoredRepository<User> userRepository)
        {
            Guard.WhenArgument(userRepository, "userRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public User GetUserById(object userId)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            return this.userRepository.GetById(userId);
        }

        public string GetAvatarFilePath(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            return this.userRepository.GetById(userId)?.AvatarPath;
        }

        public void UploadAvatar(string userId, string filePath)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(filePath, "filePath").IsNull().Throw();

            User user = this.userRepository.GetById(userId);
            if (user != null)
            {
                using (this.unitOfWork)
                {
                    user.AvatarPath = filePath;
                    this.unitOfWork.Commit();
                }
            }
        }
    }
}
