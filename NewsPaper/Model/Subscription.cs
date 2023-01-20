using NewsletterSubscription.Interfaces;

namespace NewsletterSubscription.Model
{
    internal class Subscription : ISubscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public bool IsVerified { get; set; }

        public Subscription(string name, string email, string verificationCode = null)
        {
            Name = name;
            Email = email;
            //IsVerified = false;
            VerificationCode = verificationCode ?? Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"Navn: {Name}, E-post: {Email}, Verifisert: {IsVerified}, Kode: {VerificationCode}";
        }
    }
}
