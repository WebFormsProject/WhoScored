using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;
using System.Linq;

namespace WhoScored.Services
{
    public class TrollPhotoService : ITrollPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWhoScoredRepository<TrollPhoto> trollPhotoRepository;

        public TrollPhotoService(IUnitOfWork unitOfWork, IWhoScoredRepository<TrollPhoto> trollPhotoRepository)
        {
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(trollPhotoRepository, "trollPhotoRepository").IsNull().Throw();

            this.unitOfWork = unitOfWork;
            this.trollPhotoRepository = trollPhotoRepository;
        }

        public IEnumerable<TrollPhoto> GetAll()
        {
            return this.trollPhotoRepository.GetAll();
        }

        public IEnumerable<string> GetAllPaths()
        {
            return this.GetAll().Select(p => p.PhotoPath);
        }

        public void UploadTrollPhoto(string userId, string filePath)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(filePath, "filePath").IsNull().Throw();

            TrollPhoto trollPhoto = new TrollPhoto()
            {
                UserId = userId,
                PhotoPath = filePath
            };

            this.trollPhotoRepository.Add(trollPhoto);
            this.unitOfWork.Commit();
        }
    }
}
