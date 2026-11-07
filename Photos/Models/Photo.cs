using FotoFlow.Photos.Dtos;

namespace FotoFlow.Photos.Models
{
    public class Photo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Photo()
        {
            ImageUrl = string.Empty;
            Title = string.Empty;
            UserId = Guid.Empty;
        }

        public Photo(string imageUrl, string title, Guid userId)
        {
            ImageUrl = imageUrl;
            Title = title;
            UserId = userId;
        }

        public Photo(string text)
        {
            string[] cuv = text.Split(',');
            Id = Guid.Parse(cuv[0]);
            ImageUrl = cuv[1];
            Title = cuv[2];
            UserId = Guid.Parse(cuv[3]);
            CreatedAt = DateTime.Parse(cuv[4]);
        }

        //Functions

        public override string ToString()
        {
            return Id + "," + ImageUrl + "," + Title + "," + UserId + "," + CreatedAt.ToString("yyyy-MM-dd");
        }

        public void Create(PhotoCreateRequest request)
        {
            ImageUrl = request.ImageUrl;
            Title = request.Title;
            UserId = request.UserId;
        }

        public void Update(PhotoUpdateRequest request)
        {
            ImageUrl = request.ImageUrl; Title = request.Title; UserId = request.UserId;
        }
    }
}
