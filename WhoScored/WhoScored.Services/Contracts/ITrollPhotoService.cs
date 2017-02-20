using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ITrollPhotoService
    {
        IEnumerable<TrollPhoto> GetAllTrollPhotos();

        IEnumerable<string> GetTrollPhotoPaths();
    }
}
