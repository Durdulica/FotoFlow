    using FotoFlow.Users.Dtos;
using FotoFlow.Users.Models;

namespace FotoFlow.Users.Services
{
    public class UserService
    {
        UserRepository userRepository;

        public UserService() {
           
            userRepository = new UserRepository();
        }

        //Finders

        public User FindById(Guid id)
        {
            User user = userRepository.FindById(id);

            if (user == null)
            {
                throw new ArgumentException("Userul cu acest id nu exista");
            }

            return user;
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
            get { return userRepository.GetUsers; }
        }

        public UserCreateResponse CreateUser(UserCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("Requestul dat este null");
            }

            return UserToUserCreateResponse(userRepository.CreateUser(request));
        }

        public void ReadUsers()
        {
            userRepository.Load();
        }

        public UserUpdateResponse UpdateUser(Guid id, UserUpdateRequest request) {
            if(request == null)
            {
                throw new ArgumentException("Requestul dat este null");
            }

            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id-ul este null");
            }

            User user = userRepository.UpdateUser(id, request);

            if (user == null) {
                throw new ArgumentException("Userul pe care incercati sa il modificati nu exista");
            }

            return UserToUserUpdateResponse(user);
        }

        public void DeleteUser(Guid id) {
            if (FindById(id) == null) {
                throw new ArgumentException("Userul pe care incercati sa il stergeti nu exista");
            }
            userRepository.DeleteUser(id);
        }

        public override string ToString()
        {
            return userRepository.ToString();
        }

        public void Save()
        {
            userRepository.Save();
        }
    }
}
