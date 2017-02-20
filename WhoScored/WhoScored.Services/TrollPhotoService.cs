using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class TrollPhotoService : ITrollPhotoService
    {
        private readonly IWhoScoredContext context;
        private readonly IWhoScoredRepository<TrollPhoto> trollPhotoRepository;

        public TrollPhotoService(IWhoScoredContext context, IWhoScoredRepository<TrollPhoto> trollPhotoRepository)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(trollPhotoRepository, "trollPhotoRepository").IsNull().Throw();

            this.context = context;
            this.trollPhotoRepository = trollPhotoRepository;
        }

        public IEnumerable<TrollPhoto> GetAll()
        {
            return this.trollPhotoRepository.GetAll();
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
            this.context.SaveChanges();
        }
    }
}
