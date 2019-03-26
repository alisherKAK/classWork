using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegateLesson
{
    public delegate void ReporterDelegate(string reportText);

    public class BankAccount
    {
        public event ReporterDelegate ReportEvent;

        public string FullName { get; set; }
        public int Sum { get; private set; }

        public void Add(int sum)
        {
            Sum += sum;
            ReportEvent?.Invoke($"На счет добавлено {sum}");
        }

        public void Withdraw(int sum)
        {
            if(sum <= Sum)
            {
                Sum -= sum;
                ReportEvent?.Invoke($"Со счета было снято {sum}");
                return;
            }
            ReportEvent?.Invoke("На счете не хватает средств");
        }
    }
}
