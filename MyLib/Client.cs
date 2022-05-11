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
        public int OrderTotal { get; set; }
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

        public ClientType GetClientDetail()
        {
            if (OrderTotal < 500)
            {
                return new ClientBasic();
            }
            else
            {
                return new ClientPremium();
            }
        }
    }

    public class ClientType { }

    public class ClientBasic : ClientType { }

    public class ClientPremium : ClientType { }
}
