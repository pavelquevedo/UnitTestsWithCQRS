using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Client
    {
        public string ClientName { get; set; }
        public int Discount { get; set; } = 10;
        public string CreateCompleteName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("FirstName is blank");
            }

            Discount = 30;
            ClientName = $"{firstName} {lastName}";
            return ClientName;
        }
    }
}
