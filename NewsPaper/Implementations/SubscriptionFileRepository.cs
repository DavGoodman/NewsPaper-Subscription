using System.Text.Json;
using NewsletterSubscription.Interfaces;
using NewsletterSubscription.Model;

namespace NewsletterSubscription.Implementations
{
    internal class SubscriptionFileRepository : ISubscriptionRepository
    {
        public void Save(ISubscription subscription)
        {
            var json = JsonSerializer.Serialize(subscription);
            var filename = subscription.Email + ".json";
            File.WriteAllText(filename, json);
        }

        public ISubscription Load(string email)
        {
            var filename = email + ".json";
            try
            {
                var json = File.ReadAllText(filename);
                return JsonSerializer.Deserialize<Subscription>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Email not found");
                return null;
            }
            
        }
    }
}
