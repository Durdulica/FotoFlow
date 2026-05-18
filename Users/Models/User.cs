using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoFlow.Users.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private string name;
        private string email;
        private int age;
        private string password;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Constructors

        public User() {
            name = null;
            email = null;
            age = 0;
            password = null;
        }

        public User(string name, string email, int age, string password)
        {
            Name = name;
            Email = email;
            Age = age;
            Password = password;
        }

        public User(string text)
        {
            string[] cuv = text.Split(',');
            Id = Guid.Parse(cuv[0]);
            Name = cuv[1];
            Email = cuv[2];
            Age = Int32.Parse(cuv[3]);
            Password = cuv[4];
            CreatedAt = DateTime.Now;
        }

        //Incapsulare

        public string Name { 
            get { return name; } 
            set { 
                if(value.Length == 0)
                {
                    throw new ArgumentException("Numele userului trebuie nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 4 || text.Length > 20) {
                    throw new ArgumentException("Username-ul trebuie sa aiba intre 4 si 20 de caractere");
                }

                foreach(char c in text)
                {
                    bool caracterPermis = Char.IsLetterOrDigit(c) && c == '_' && c == '.';
                    if (caracterPermis) {
                        throw new ArgumentException("Numele contine caractere nepermise");
                    }
                }
                name = value; 
            } 
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Emailul nu poate fi gol");
                }

                if (value.Length < 7 || value.Length > 40)
                {
                    throw new ArgumentException("Emailul trebuie sa aiba intre 7 si 40 de caractere");
                }

                string text = value.Trim();

                if (!text.Contains("@gmail") && !text.Contains("@yahoo") && !text.Contains("@hotmail"))
                {
                    throw new ArgumentException("Email incomplet");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetterOrDigit(ch) || ch == '@' || ch == '.';

                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Emailul contine caractere nepermise");
                    }
                }
                email = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 12)
                {
                    throw new ArgumentException("Userul este prea tanar");
                }
                age = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 8)
                {
                    Console.WriteLine("Parola trebuie sa aiba cel putin 8 caractere");
                }

                string text = value.Trim();

                bool numere = false;
                bool caractereSpeciale = false;

                foreach (char ch in text) {
                    if (Char.IsDigit(ch)) {
                        numere = true;
                    }
                    else if(ch == '!' || ch == '@' || ch == '#' || ch == '$' || ch == '%' || ch == '&' || ch == '?')
                    {
                        caractereSpeciale = true;
                    }
                    else if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Parola contine caractere nepermise");
                    }
                }

                if (!numere)
                {
                    throw new ArgumentException("Parola trebuie sa contina cel putin un numar");
                }

                if (!caractereSpeciale)
                {
                    throw new ArgumentException("Parola trebuie sa contine cel putin un caracter special");
                }

                password = value;
            }
        }
    }
}
