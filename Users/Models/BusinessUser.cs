using System.Xml.Linq;

namespace FotoFlow.Users.Models
{
    public class BusinessUser : User
    {
        public string BusinessName { get; set; }
        public string TaxId { get; set; }
        public string Website { get; set; }

        //Constructors

        public BusinessUser() : base() 
        {
            BusinessName = string.Empty;
            TaxId = string.Empty;
            Website = string.Empty;
        }

        public BusinessUser(string name, string email, int age, string password, string businessName, string taxId, string website) 
            : base(name, email, age, password)
        {
            BusinessName = businessName;
            TaxId = taxId;
            Website = website;
        }

        public BusinessUser(string text) : base(text) {
            string[] cuv = text.Split(',');
            BusinessName = cuv[7];
            TaxId = cuv[8];
            Website = cuv[9];
        }

        //Functions

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "BUSINESS," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," + CreatedAt.ToString("dd-MM-yyyy")
                    + "," + BusinessName + "," + TaxId + "," + Website;
            }
            else
            {
                list += "BUSINESS," + Id + "," + Name + "," + Email + "," + Age + "," + Password + "," + CreatedAt.ToString("dd-MM-yyyy")
                    + "," + BusinessName + "," + TaxId + "," + Website + '\n';
            }
            return list;
        }

        public override string GetProfileBadge()
        {
            return "🏢";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Business: {BusinessName}");
            Console.WriteLine($"Tax ID: {TaxId}");
            Console.WriteLine($"Website: {Website}");
        }
    }
}
