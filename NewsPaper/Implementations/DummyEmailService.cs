using NewsletterSubscription.Interfaces;
using NewsletterSubscription.Model;

namespace NewsletterSubscription.Implementations
{
    internal class DummyEmailService : IEmailService
    {
        public void Send(IEmail email)
        {
            Console.WriteLine(email);
        }
    }
}
