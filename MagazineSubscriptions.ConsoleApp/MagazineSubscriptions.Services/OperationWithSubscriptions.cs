using MagazineSubscriptions.DataAccess;
using MagazineSubscriptions.Models;
using System;
using System.Linq;

namespace MagazineSubscriptions.Services
{
    public static class OperationWithSubscriptions
    {
        public static void DeleteSubsription(User user)
        {
            using (var context = new MagazineContext())
            {
                var userSub = context.UsersSubscriptions.Where(userSubscription => userSubscription.User.Id == user.Id).SingleOrDefault();
                if (userSub != null)
                {
                    context.UsersSubscriptions.Remove(userSub);
                    context.SaveChanges();
                    return;
                }

                throw new ArgumentNullException("Нет такого пользователя с такой подпиской");
            }
        }

        public static UsersSubscription AddSubsription(User user, SubsritionsType subsritionsType)
        {
            using (var context = new MagazineContext())
            {
                UsersSubscription newUsersSubscription = new UsersSubscription()
                {
                    Subscription = context.Subscriptions.Where(sub => sub.SubscriptionsTimeInMonth == (int)subsritionsType).SingleOrDefault(),
                    User = context.Users.Where(searchUser => searchUser.Id == user.Id).SingleOrDefault()
                };

                context.UsersSubscriptions.Add(newUsersSubscription);
                context.SaveChanges();

                return newUsersSubscription;
            }
        }
    }
}
