namespace NewsletterSubscription.Interfaces
{
    internal interface IEmail
    {
        string From { get; set; }
        string Subject { get; set; }
        string Text { get; set; }
        string To { get; set; }

        string ToString();
    }
}