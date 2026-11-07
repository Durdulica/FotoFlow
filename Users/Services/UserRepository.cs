using FotoFlow.Users.Dtos;
using FotoFlow.Users.Models;

namespace FotoFlow.Users.Services
{
    public class UserRepository
    {
        List<User> users = new List<User>();

        public List<User> GetUsers { get { return users; } }

        public User FindById(Guid id)
        {
            foreach (var user in users)
            {
                if(user.Id == id) return user;
            }

            return null;
        }

        //CRUD

        public User CreateUser(UserCreateRequest request)
        {
            User user = new User();

            user.Create(request);
            users.Add(user);

            return user;
        }

        public void Load()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");

            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] cuv = line.Split(',');
                    switch (cuv[0])
                    {
                        case "USER": users.Add(new User(line)); break;
                        case "REGULAR": users.Add(new RegularUser(line)); break;
                        case "CREATOR": users.Add(new CreatorUser(line)); break;
                        case "BUSINESS": users.Add(new BusinessUser(line)); break;
                        case "ADMIN": users.Add(new Admin(line)); break;
                    }
                }
            }
        }

        public User UpdateUser(Guid id, UserUpdateRequest request)
        {
            User user = FindById(id);

            user.Update(request);

            return user;
        }

        public void DeleteUser(Guid id)
        {
            User user = FindById(id);
            users.Remove(user);
        }

        public override string ToString()
        {
            string list = "";
            for (int i = 0; i < users.Count - 1; i++)
            {
                list += users[i].ToString() + '\n';
            }

            list += users[users.Count - 1].ToString();
            return list;
        }
        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");

            using (var writer = new StreamWriter(path))
            {
                writer.Write(this);
            }
        }
    }
}