using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Interface
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterWithdrawal(int balance);
        string MessageReturnsString(string message);
        bool MessageReturnsStringReturnBool(string str, out string outputStr);
        bool MessageWithReferenceObjectReturnBool(ref Client client);
    }
}
