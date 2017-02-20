using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ITrollPhotoService
    {
        IEnumerable<TrollPhoto> GetAll();

        IEnumerable<string> GetAllPaths();

        void UploadTrollPhoto(string userId, string filePath);
    }
}
