using NewsletterSubscription.Model;

namespace NewsletterSubscription.Interfaces
{
    internal interface ISubscriptionRepository
    {
        void Save(ISubscription subscription);
        ISubscription Load(string email);
    }
}
