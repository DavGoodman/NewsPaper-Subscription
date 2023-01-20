using NewsletterSubscription.Implementations;
using NewsletterSubscription.Interfaces;
using NewsletterSubscription.Model;

namespace NewsPaper
{
    internal class Factory
    {
        public static IEmail CreateEmail(string to, string from, string subject, string text = null)
        {
            return new Email(to, from, subject, text);
        }

        public static ISubscription CreateSubscription(string name, string email, string verificationCode = null)
        {
            return new Subscription(name, email, verificationCode);
        }

        public static IEmailService CreateEmailService()
        {
            return new DummyEmailService();
        }

        public static ISubscriptionRepository CreateSubscriptionRepository()
        {
            return new SubscriptionFileRepository();
        }

    }
}
