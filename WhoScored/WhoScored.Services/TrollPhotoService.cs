using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class TrollPhotoService : ITrollPhotoService
    {
        private readonly IWhoScoredRepository<TrollPhoto> trollPhotoRepository;

        public TrollPhotoService(IWhoScoredRepository<TrollPhoto> trollPhotoRepository)
        {
            Guard.WhenArgument(trollPhotoRepository, "trollPhotoRepository").IsNull().Throw();

            this.trollPhotoRepository = trollPhotoRepository;
        }

        public IEnumerable<TrollPhoto> GetAllTrollPhotos()
        {
            return this.trollPhotoRepository.GetAll();
        }

        public IEnumerable<string> GetTrollPhotoPaths()
        {
            return this.trollPhotoRepository.GetAll().Select(x=>x.PhotoPath);
        }
    }
}
