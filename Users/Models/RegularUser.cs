using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FotoFlow.Users.Models
{
    public class RegularUser : User
    {
        public string Bio {  get; set; }
        public string AvatarUrl { get; set; }

        //Constructors

        public RegularUser() : base() { }

        public RegularUser(string name, string email, int age, string password, string bio, string avatarUrl = null) 
            : base(name, email, age, password) {
            Bio = bio;
            AvatarUrl = avatarUrl;
        }

        public RegularUser(string text) : base(text) {
            string[] cuv = text.Split(',');
            Bio = cuv[7];
            AvatarUrl = cuv[8];
        }

        //Functions

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "REGULAR," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," 
                    + CreatedAt.ToString("dd-MM-yyyy") + "," + Bio + "," + AvatarUrl;
            }
            else
            {
                list += "REGULAR," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," 
                    + CreatedAt.ToString("dd-MM-yyyy") + "," + Bio + "," + AvatarUrl + '\n';
            }
            return list;
        }

        public virtual string GetProfileBadge()
        {
            return base.GetProfileBadge();
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Regular User: {Name}");
            Console.WriteLine($"Bio: {Bio}");
        }
    }
}
