using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_driven_architecture
{
    public interface ILogger
    {
        void LogDebug(string message);
        void LogInformation(string message);
        void LogError(string message);
    }
}
