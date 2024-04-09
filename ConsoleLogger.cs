using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_driven_architecture
{
    public class ConsoleLogger : ILogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine($"[Log] {message}", ConsoleColor.DarkGray);
        }

        public void LogInformation(string message)
        {
            Console.WriteLine($"[Log] {message}", ConsoleColor.White);
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[Log] {message}", ConsoleColor.Red);
        }
    }
}
