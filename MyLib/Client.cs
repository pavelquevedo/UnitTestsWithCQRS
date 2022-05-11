using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public interface IClient
    {
        string ClientName { get; set; }
        int Discount { get; set; }
        int OrderTotal { get; set; }
        bool IsPremium { get; set; }

        ClientType GetClientDetail();
        string CreateCompleteName(string firstName, string lastName);
    }
    public class Client : IClient
    {
        public string ClientName { get; set; }
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPremium { get; set; }

        public Client()
        {
            Discount = 10;
            IsPremium = false;
        }

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
