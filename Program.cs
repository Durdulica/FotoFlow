using FotoFlow.Photos.Dtos;
using FotoFlow.Photos.Services;
using FotoFlow.Users.Dtos;
using FotoFlow.Users.Models;
using FotoFlow.Users.Services;

internal class Program
{
    private static void Main()
    {
        try
        {
            PhotoService service = new PhotoService();
            //PhotoCreateRequest req = new PhotoCreateRequest(test,photo5,366b1330-ede6-4423-86e5-42ac0e809826);
            //service.CreatePhoto(req);
            service.Save();
        }
        catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }
    }
}