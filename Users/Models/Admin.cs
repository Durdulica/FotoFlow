using FotoFlow.Users.Dtos;

namespace FotoFlow.Users.Models
{
    public class Admin : User
    {
        public int AdminLevel { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();


        public Admin() : base() { }

        public Admin(string name, string email, int age, string password, int adminLevel) : base(name, email, age, password)
        {
            AdminLevel = adminLevel;
        }

        public Admin(string text) : base(text) 
        {
            string[] cuv = text.Split(',');
            AdminLevel = Int32.Parse(cuv[7]);
        }

        //Functions

        public override string ToString()
        {
            return "ADMIN," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," + CreatedAt.ToString("yyyy-MM-dd")
                + "," + AdminLevel;
        }

        /*public override void Create(AdminCreateRequest request)
         {
             Name = request.Name;
             Email = request.Email;
             Age = request.Age;
             Password = request.Password;
         }

         public override void Update(AdminUpdateRequest request)
         {
             Name = request.Name;
             Email = request.Email;
             Age = request.Age;
             Password = request.Password;
         }*/

        public override string GetProfileBadge()
        {
            return "🛡️";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Admin: {Name}, Email: {Email}, Age: {Age}, Created at: {CreatedAt}, Password: {Password} (Level {AdminLevel})");
            Console.WriteLine($"Permissions: {string.Join(", ", Permissions)}");
        }

        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
    }
}
