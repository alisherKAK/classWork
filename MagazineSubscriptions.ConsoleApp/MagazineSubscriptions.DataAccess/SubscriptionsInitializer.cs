using MagazineSubscriptions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MagazineSubscriptions.DataAccess
{
    public class SubscriptionsInitializer : CreateDatabaseIfNotExists<MagazineContext>
    {
        protected override void Seed(MagazineContext context)
        {
            context.Subscriptions.AddRange(new List<Subscription>()
            {
                new Subscription() {Price = 100, SubscriptionsTimeInMonth = 12},
                new Subscription() {Price = 200, SubscriptionsTimeInMonth = 24},
                new Subscription() {Price = 300, SubscriptionsTimeInMonth = 36}
            });

            context.Magazines.AddRange(new List<Magazine>
            {
                new Magazine() { Name = "NationalGeography", Theme = "Science", DateOfIssue = DateTime.Now}
            });

            context.SaveChanges();
        }
    }
}
