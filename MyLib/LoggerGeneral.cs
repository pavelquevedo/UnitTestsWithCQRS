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
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
