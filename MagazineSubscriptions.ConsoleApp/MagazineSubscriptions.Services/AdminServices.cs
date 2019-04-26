using MagazineSubscriptions.DataAccess;
using MagazineSubscriptions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagazineSubscriptions.Services
{
    public static class AdminServices
    {
        public static void CreateMagazine()
        {
            Magazine newMagazine = new Magazine()
            {
                Name = SetInformation.SetName(),
                Theme = SetInformation.SetTheme(),
                DateOfIssue = DateTime.Now
            };

            using(var context = new MagazineContext())
            {
                context.Magazines.Add(newMagazine);
                context.SaveChanges();
            }
        }

        public static void MakeEarningsRepors()
        {
            string month = ((Month)DateTime.Now.Month).ToString();

            using (FileStream fileStream = new FileStream("earningsReport.csv", FileMode.OpenOrCreate))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            using(var context = new MagazineContext())
            {
                double earning = context.UsersSubscriptions.Where(userSub => userSub.Subscription.SubscriptionsTimeInMonth == DateTime.Now.Month).ToList().Sum(sum => sum.Subscription.Price);
                streamWriter.WriteLine("Month;Earning");
                streamWriter.WriteLine($"{month};{earning}");
            }
        }

        public static void MakeSubsRepors()
        {
            string month = ((Month)DateTime.Now.Month).ToString();

            using (FileStream fileStream = new FileStream("earningsReport.csv", FileMode.OpenOrCreate))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            using (var context = new MagazineContext())
            {
                int subsCount = context.UsersSubscriptions.Where(userSub => userSub.Subscription.SubscriptionsTimeInMonth == DateTime.Now.Month).ToList().Count;
                streamWriter.WriteLine("Month;SubsCount");
                streamWriter.WriteLine($"{month};{subsCount}");
            }
        }

        public static void CreateMagazineShipping(UsersSubscription usersSubscription)
        {
            using (var context = new MagazineContext())
            {
                List<MagazineShipping> magazines = new List<MagazineShipping>();

                foreach (Magazine magazine in context.Magazines.ToList())
                {
                    MagazineShipping newMagazineShipping = new MagazineShipping()
                    {
                        UsersSubscription = usersSubscription,
                        Magazine = magazine,
                        DeliverTime = DateTime.Now,
                        IsDelivered = true
                    };
                    magazines.Add(newMagazineShipping);
                }

                do
                {
                    Console.WriteLine("Если вы получили все журналы нажмите на 1");

                    string delivered = Console.ReadLine().Trim();

                    if (delivered == "1")
                    {
                        context.MagazineShippings.AddRange(magazines);
                        context.SaveChanges();
                        break;
                    }
                } while (true);
            }
        }
    }
}
