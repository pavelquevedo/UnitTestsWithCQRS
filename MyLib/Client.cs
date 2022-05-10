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
        public string CreateCompleteName(string firstName, string lastName)
        {
            ClientName = $"{firstName} {lastName}";
            return ClientName;
        }
    }
}
