namespace WhoScored.Services.Contracts
{
    public interface IUserAvatarService
    {
        string GetAvatarFilePath(string userId);

        void UploadAvatar(string userId, string avatarFilePath);
    }
}
