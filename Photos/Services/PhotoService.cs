using FotoFlow.Photos.Dtos;
using FotoFlow.Photos.Models;

namespace FotoFlow.Photos.Services
{
    public class PhotoService
    {
        readonly PhotoRepository photoRepository = new();

        //Finders

        public Photo FindById(Guid id)
        {
            return photoRepository.FindById(id);
        }

        //Mappers

        public PhotoCreateResponse PhotoToPhotoCreateResponse(Photo photo)
        {
            return new PhotoCreateResponse
            {
                ImageUrl = photo.ImageUrl,
                Title = photo.Title,
                UserId = photo.UserId
            };
        }

        public PhotoUpdateResponse PhotoToPhotoUpdateResponse(Photo photo)
        {
            return new PhotoUpdateResponse
            {
                ImageUrl = photo.ImageUrl,
                Title = photo.Title,
                UserId = photo.UserId
            };
        }

        //CRUD

        public List<Photo> GetPhotos
        {
            get { return photoRepository.GetPhotos; }
        }

        public PhotoCreateResponse CreatePhoto(PhotoCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Requestul dat este null");
            }

            return PhotoToPhotoCreateResponse(photoRepository.CreatePhoto(request));
        }

        public void ReadUsers()
        {
            photoRepository.Load();
        }

        public PhotoUpdateResponse UpdatePhoto(Guid id, PhotoUpdateRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id-ul este null");
            }

            if (request == null)
            {
                throw new ArgumentException("Requestul este null");
            }

            photoRepository.UpdatePhoto(id, request);

            Photo photo = photoRepository.UpdatePhoto(id, request);

            if (photo == null)
            {
                throw new ArgumentException("Poza pe care incercati sa o modificati nu exista");
            }

            return PhotoToPhotoUpdateResponse(photo);
        }

        public void DeletePhoto(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id-ul pozei pe care incercati sa o modificati este null");
            }
            photoRepository.DeletePhoto(id);
        }

        public override string ToString()
        {
            return photoRepository.ToString();
        }

        public void Save()
        {
            photoRepository.Save();
        }
    }
}
