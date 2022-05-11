using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Interface
{
    public interface ILoggerGeneral
    {
        public int Priority { get; set; }
        public string Type { get; set; }
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterWithdrawal(int balance);
        string MessageReturnsString(string message);
        bool MessageReturnsStringReturnBool(string str, out string outputStr);
        bool MessageWithReferenceObjectReturnBool(ref Client client);
    }
}
