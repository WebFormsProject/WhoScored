using Bytes2you.Validation;
using System;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class UserPhotoUploadEventArgs : EventArgs
    {
        public UserPhotoUploadEventArgs(HttpPostedFileBase postedFileBase, string filePath, string storageLocation, string userId)
        {
            Guard.WhenArgument(postedFileBase, "postedFileBase").IsNull().Throw();
            Guard.WhenArgument(filePath, "filePath").IsNull().Throw();
            Guard.WhenArgument(storageLocation, "storageLocation").IsNull().Throw();
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            this.PostedFileBase = postedFileBase;
            this.FilePath = filePath;
            this.StorageLocation = storageLocation;
            this.UserId = userId;
        }

        public HttpPostedFileBase PostedFileBase { get; set; }

        public string FilePath { get; set; }

        public string StorageLocation { get; set; }

        public string UserId { get; set; }
    }
}
