using FotoFlow.Photos.Dtos;
using FotoFlow.Photos.Models;

namespace FotoFlow.Photos.Services
{
    public class PhotoRepository
    {
        List<Photo> photos = new List<Photo>();

        public PhotoRepository()
        {
            Load();
        }

        //Finders

        public Photo FindById(Guid id)
        {
            foreach (Photo p in photos)
            {
                if (p.Id == id) return p;
            }
            return null;
        }

        //CRUD

        public List<Photo> GetPhotos
        {
            get { return photos; }
        }

        public Photo CreatePhoto(PhotoCreateRequest request)
        {
            Photo photo = new Photo();

            photo.Create(request);
            photos.Add(photo);

            return photo;
        }

        public void Load()
        {
            string path = Path.Combine("..", "..", "..", "Data", "photos.txt");

            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    photos.Add(new Photo(line));
                }
            }
        }

        public Photo UpdatePhoto(Guid id, PhotoUpdateRequest request)
        {
            Photo photo = FindById(id);

            photo.Update(request);

            return photo;
        }

        public void DeletePhoto(Guid id)
        {
            Photo photo = FindById(id);
            photos.Remove(photo);
        }

        public override string ToString()
        {
            string list = "";
            for(int i = 0; i < photos.Count - 1; i++)
            {
                list += photos[i].ToString() + '\n';
            }
            list += photos[photos.Count - 1].ToString();

            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "photos.txt");
            using (var writer = new StreamWriter(path)) {
                writer.Write(this);
            }
        }
    }
}