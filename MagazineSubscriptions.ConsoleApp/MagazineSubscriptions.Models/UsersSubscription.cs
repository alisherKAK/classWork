using MagazineSubscriptions.AbstractModels;

namespace MagazineSubscriptions.Models
{
    public class UsersSubscription : Entity
    {
        public User User { get; set; }
        public Subscription Subscription { get; set; }
    }
}
