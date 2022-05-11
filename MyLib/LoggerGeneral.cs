using MyLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceAfterWithdrawal(int balance)
        {
            if(balance >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageReturnsString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool MessageReturnsStringReturnBool(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool MessageWithReferenceObjectReturnBool(ref Client client)
        {
            return true;
        }
    }
}
