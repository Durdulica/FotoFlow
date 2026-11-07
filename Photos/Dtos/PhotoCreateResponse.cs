namespace FotoFlow.Photos.Dtos
{
    public class PhotoCreateResponse
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}
