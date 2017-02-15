using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using WhoScored.WebFormsClient.Services.Contracts;

namespace WhoScored.WebFormsClient.Services
{
    public class TrollPhotosService : ITrollPhotosService
    {
        public IList<string> GetImages(string directory)
        {
            IList<string> slides = new List<string>();

            string path = HttpContext.Current.Server.MapPath(directory);
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1);
            }

            Uri pathUri = new Uri(path, UriKind.Absolute);
            string[] filesPaths = Directory.GetFiles(path);
            foreach (string filePath in filesPaths)
            {
                Uri filePathUri = new Uri(filePath, UriKind.Absolute);
                slides.Add($"/{pathUri.MakeRelativeUri(filePathUri).ToString()}");
            }

            return slides;
        }
    }
}