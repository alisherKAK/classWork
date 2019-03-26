using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegateLesson
{
    public interface IReporter
    {
        void SendReport(string text);
    }
}
