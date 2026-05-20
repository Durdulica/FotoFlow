using System.Xml.Linq;

namespace FotoFlow.Users.Models
{
    public class CreatorUser : User
    {
        public string Bio {  get; set; }
        public bool MonetizationEnabled { get; set; }
        public string PayoutAccount { get; set; }
        public int FollowerCount { get; set; }

        //Constructors

        public CreatorUser() : base() 
        {
            Bio = null;
            MonetizationEnabled = false;
            PayoutAccount = null;
            FollowerCount = 0;
        }

        public CreatorUser(string name, string email, int age, string password, string bio, bool monetization, string payout, int followers)
            : base(name, email, age, password) {
            Bio = bio;
            MonetizationEnabled = monetization;
            PayoutAccount = payout;
            FollowerCount = followers;
        }

        public CreatorUser(string text) : base(text) {
            string[] cuv = text.Split(',');
            Bio = cuv[7];
            MonetizationEnabled = bool.Parse(cuv[8]);
            PayoutAccount = cuv[9];
            FollowerCount = int.Parse(cuv[10]);
        }

        //Functions

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "CREATOR," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," + CreatedAt.ToString("dd-MM-yyyy")
                    + "," + Bio + "," + MonetizationEnabled + "," + PayoutAccount + "," + FollowerCount;
            }
            else
            {
                list += "CREATOR," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," + CreatedAt.ToString("dd-MM-yyyy") 
                    + "," + Bio + "," + MonetizationEnabled + "," + PayoutAccount + "," + FollowerCount + '\n';
            }
            return list;
        }

        public override string GetProfileBadge()
        {
            return "⭐";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Creator: {Name}");
            Console.WriteLine($"Followers: {FollowerCount}");
            Console.WriteLine($"Monetization: {(MonetizationEnabled ? "ON" : "OFF")}");
        }
    }
}
