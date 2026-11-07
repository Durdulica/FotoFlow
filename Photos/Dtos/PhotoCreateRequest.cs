namespace FotoFlow.Photos.Dtos
{
    public class PhotoCreateRequest
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }

        public PhotoCreateRequest(string imageUrl, string title, Guid userId)
        {
            ImageUrl = imageUrl;
            Title = title;
            UserId = userId;
        }
    }
}
