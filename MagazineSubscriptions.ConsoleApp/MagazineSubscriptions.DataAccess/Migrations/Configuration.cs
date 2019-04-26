namespace MagazineSubscriptions.DataAccess.Migrations
{
    using MagazineSubscriptions.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MagazineSubscriptions.DataAccess.MagazineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MagazineSubscriptions.DataAccess.MagazineContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Subscriptions.AddRange(new List<Subscription>()
            {
                new Subscription() {Price = 100, SubscriptionsTimeInMonth = 12},
                new Subscription() {Price = 200, SubscriptionsTimeInMonth = 24},
                new Subscription() {Price = 300, SubscriptionsTimeInMonth = 36}
            });

            context.SaveChanges();
        }
    }
}
