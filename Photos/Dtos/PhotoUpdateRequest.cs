namespace FotoFlow.Photos.Dtos
{
    public class PhotoUpdateRequest
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }

        public PhotoUpdateRequest(string imageUrl, string title, Guid userId)
        {
            ImageUrl = imageUrl;
            Title = title;
            UserId = userId;
        }
    }
}
