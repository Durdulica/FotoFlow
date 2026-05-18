using FotoFlow.Users.Dtos;
using FotoFlow.Users.Services;

internal class Program
{
    private static void Main()
    {
        try
        {
            UserService service = new UserService();
            UserCreateRequest request = new UserCreateRequest("Stefan","stefanel.scarlat@gmail.com",18,"123abcd!");
            service.CreateUser(request);
            service.Save();
        }
        catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }
    }
}