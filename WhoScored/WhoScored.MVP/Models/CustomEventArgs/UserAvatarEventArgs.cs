using Bytes2you.Validation;
using System;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class UserAvatarEventArgs : EventArgs
    {
        public UserAvatarEventArgs(HttpPostedFileBase postedFileBase, string avatarFilePath, string avatarStorageLocation, string userId)
        {
            Guard.WhenArgument(postedFileBase, "postedFileBase").IsNull().Throw();
            Guard.WhenArgument(avatarFilePath, "avatarFilePath").IsNull().Throw();
            Guard.WhenArgument(avatarStorageLocation, "avatarStorageLocation").IsNull().Throw();
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            this.PostedFileBase = postedFileBase;
            this.AvatarFilePath = AvatarFilePath;
            this.AvatarStorageLocation = avatarStorageLocation;
            this.UserId = userId;
        }

        public HttpPostedFileBase PostedFileBase { get; set; }

        public string AvatarFilePath { get; set; }

        public string AvatarStorageLocation { get; set; }

        public string UserId { get; set; }
    }
}
