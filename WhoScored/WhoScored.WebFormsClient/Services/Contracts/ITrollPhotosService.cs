using System.Collections.Generic;

namespace WhoScored.WebFormsClient.Services.Contracts
{
    public interface ITrollPhotosService
    {
        IList<string> GetImages(string directory);
    }
}
