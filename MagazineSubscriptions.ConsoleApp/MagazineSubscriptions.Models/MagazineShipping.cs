using MagazineSubscriptions.AbstractModels;
using System;

namespace MagazineSubscriptions.Models
{
    public class MagazineShipping : Entity
    {
        public UsersSubscription UsersSubscription { get; set; }
        public Magazine Magazine { get; set; }
        public DateTime DeliverTime { get; set; }
        public bool IsDelivered { get; set; }
    }
}
