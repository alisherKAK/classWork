using HomeWork28_04_19.DataAccess;
using HomeWork28_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28_04_19.Services
{
    public static class RecordsService
    {
        public static void CraeteReacord()
        {
            Person newPerson = new Person()
            {
                Name = SetInformations.SetName(),
                CertificateNumber = SetInformations.SetCertificateNumber()
            };

            Ledger newRecord = new Ledger()
            {
                Person = newPerson,
                EnterTime = DateTime.Now, 
                ExitTime = null, 
                PersonId = newPerson.Id,
                VisitPurpose = SetInformations.SetVisitPurpose()
            };

            using(var context = new LedgerContext())
            {
                context.People.Add(newPerson);
                context.Ledgers.Add(newRecord);
                context.SaveChanges();
            }
        }

        public static void FinishRecord()
        {
            try
            {
                Guid personId = SetInformations.SetPersonId();

                using (var context = new LedgerContext())
                {
                    var leavingPerson = context.People.Find(personId);
                    var ledgers = context.Ledgers.ToList();

                    for (int i = 0; i < ledgers.Count; i++)
                    {
                        if (ledgers[i].PersonId == leavingPerson.Id)
                        {
                            context.Ledgers.Remove(ledgers[i]);
                            context.SaveChanges();
                            ledgers[i].ExitTime = DateTime.Now;
                            context.Ledgers.Add(ledgers[i]);
                            context.SaveChanges();
                            break;
                        }
                    }
                }
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.ParamName);
            }
        }
    }
}
