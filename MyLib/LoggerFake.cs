using MyLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class LoggerFake : ILoggerGeneral
    {
        public int Priority { get; set; }
        public string Type { get; set; }

        public bool LogBalanceAfterWithdrawal(int balance)
        {
            return false;
        }

        public bool LogDatabase(string message)
        {
            return false;
        }

        public void Message(string message)
        {
            
        }

        public string MessageReturnsString(string message)
        {
            return message;
        }

        public bool MessageReturnsStringReturnBool(string str, out string outputStr)
        {
            outputStr = str;
            return true;
        }

        public bool MessageWithReferenceObjectReturnBool(ref Client client)
        {
            return true;
        }
    }
}
