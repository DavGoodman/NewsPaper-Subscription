using NewsletterSubscription.Interfaces;
using NewsletterSubscription.Model;
using NewsletterSubscription;
using NewsPaper;

namespace NewsletterSubscription
{
    internal class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(
            IEmailService emailService, 
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _emailService = emailService;
        }

        public void Subscribe(string name, string emailAddress)
        {
            ISubscription subscription = Factory.CreateSubscription(name , emailAddress, "verCode123" );
            _subscriptionRepository.Save(subscription);
            IEmail email = Factory.CreateEmail(
                name, "NewsLetterCo", "Verification code", $"Your verification code is: {subscription.VerificationCode}"
                );
            _emailService.Send(email);
        }

        public void Verify(string emailAddress, string verificationCode)
        {
            ISubscription sub = _subscriptionRepository.Load(emailAddress);

            if(sub == null ) return;
            if (sub.IsVerified)
            {
                Console.WriteLine("User already verified");
                return;
            }

            if (sub.VerificationCode == verificationCode)
            {
                sub.IsVerified = true;
                _subscriptionRepository.Save(sub);

                IEmail email = Factory.CreateEmail(
                    sub.Name, "NewsLetterCo", "Verification code", "You have been successfully verified"
                );
                _emailService.Send(email);
                return;
            }

            Console.WriteLine("Incorrect code or email");
        }
    }
}
