using FotoFlow.Users.Dtos;
using FotoFlow.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoFlow.Users.Services
{
    public class UserService
    {
        List<User> users = new List<User>();

        public UserService() {
        
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
            return new User(request.FirstName, request.LastName, request.Email, request.Age);
        }

        public UserCreateResponse UserToUserCreateResponse(User user)
        {
            return new UserCreateResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }

        public UserUpdateResponse UserToUserUpdateResponse(User user)
        {
            return new UserUpdateResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }
    }
}
