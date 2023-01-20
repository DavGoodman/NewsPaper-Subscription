namespace NewsletterSubscription.Interfaces
{
    internal interface ISubscription
    {
        string Email { get; set; }
        bool IsVerified { get; set; }
        string Name { get; set; }
        string VerificationCode { get; set; }

        string ToString();
    }
}