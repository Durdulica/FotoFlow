using FotoFlow.Users.Dtos;
using FotoFlow.Users.Models;

namespace FotoFlow.Users.Services
{
    public class UserService
    {
        List<User> users = new List<User>();

        public UserService() {
            ReadUsers();
        }

        //Finders

        User FindById(Guid id)
        {
            foreach (var user in users)
            {
                if (user.Id == id) return user;
            }
            return null;
        }

        //Mappers

        public User UserCreateRequestToUser(UserCreateRequest request)
        {
            return new User(request.Name, request.Email, request.Age, request.Password);
        }

        public UserCreateResponse UserToUserCreateResponse(User user)
        {
            return new UserCreateResponse()
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Password = user.Password
            };
        }

        public UserUpdateResponse UserToUserUpdateResponse(User user)
        {
            return new UserUpdateResponse()
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Password = user.Password
            };
        }

        //CRUD

        public List<User> getUsers
        {
            get { return users; }
        }

        public UserCreateResponse CreateUser(UserCreateRequest request) {
            User newUser = new();

            newUser.Create(request);
            users.Add(newUser);

            return UserToUserCreateResponse(newUser);
        }

        private void ReadUsers()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");
            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(new User(line));
                }
            }
        }

        public UserUpdateResponse UpdateUser(Guid id, UserUpdateRequest request) {
            User user = FindById(id);

            if (user == null) {
                throw new ArgumentException("Userul pe care incercati sa il modificati nu exista");
            }

            user.Update(request);

            return UserToUserUpdateResponse(user);
        }

        public void DeleteUser(Guid id) {
            User user = FindById(id);
            users.Remove(user);
        }

        public string UserListToString()
        {
            string list = "";
            for (int i = 0; i < users.Count; i++)
            {
                list += users[i].ToText(i, users.Count);
            }
            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");

            using (var writer = new StreamWriter(path))
            {
                string list = UserListToString();
                writer.Write(list);
            }
        }
    }
}
