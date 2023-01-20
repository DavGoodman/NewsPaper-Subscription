using NewsletterSubscription.Model;

namespace NewsletterSubscription.Interfaces
{
    internal interface IEmailService
    {
        void Send(IEmail email);
    }
}
